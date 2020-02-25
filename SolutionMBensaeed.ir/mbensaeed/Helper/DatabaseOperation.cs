using mbensaeed.Models;
using mbensaeed.OpratingClasses;
using mbensaeed.Repositories;
using mbensaeed.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mbensaeed.Helper
{
    public class DatabaseOperation
    {
        NetworkOperation objNetworkOperation = new NetworkOperation();
        public IEnumerable<vm_AllPost> GetAllPost(string PostCount)
        {
            using (var _Context = new ApplicationDbContext())
            {
                var _objEntityPost = new RepositoryPattern<Post>(_Context);
                var _post = _objEntityPost.SearchFor(x => x.IsActive == "1").ToList();

                var _objEntityCategory = new RepositoryPattern<Category>(_Context);
                var _category = _objEntityCategory.GetAll();

                var _objEntityImage = new RepositoryPattern<Image>(_Context);
                var _image = _objEntityImage.GetAll();

                var Result = new List<vm_AllPost>();

                Result = (from pst in _post
                          join im in _image
                          on pst.ImageID equals im.ID
                          join cat in _category
                          on pst.CategoryID equals cat.ID
                        //join ac in _activity
                        //on pst.ID equals ac.Posts.ID into act
                        //from PstAc in act.DefaultIfEmpty()
                          select new vm_AllPost
                          {
                              PostID = pst.ID,
                              Content = pst.Content,
                              LikeCount = pst.Activity.Where(x=>x.ActivityTypeId == 2).Count(),//totalCount(ac.Posts.ID),
                              Category = cat.DescriptionFa,
                              Labels = pst.Labels,
                              PostDate = pst.PostDate,
                              PostTime = pst.PostTime,
                              Title = pst.Title,
                              ViewCount = pst.Activity.Where(x => x.ActivityTypeId == 1).Count(),
                              ImageUrl = im.FileUrl.Substring(1),//_image.Single(x=>x.ID==pst.ImageID).FileUrl, //pst.Image.FileUrl,
                              IsActive = pst.IsActive,
                              CategoryID=pst.CategoryID
                          }
                            ).OrderByDescending(x => x.PostTime)
                            .ThenByDescending(x => x.PostDate)
                           .ToList();

                _objEntityPost.Dispose();
                _objEntityCategory.Dispose();
                _objEntityImage.Dispose();

                if (PostCount == "all")
                {
                    return Result;
                }
                else if (Convert.ToInt32(PostCount) > 0)
                {
                    return Result.Take(Convert.ToInt32(PostCount));
                }
                else
                {
                    return Result;
                }
            }
        }

        public void PostLog(int PostID, int ActionTypeID)
        {
            var _Browser = objNetworkOperation.ClientBrowser();
            var _Device = objNetworkOperation.ClientDeviceType();
            var _IP_Address = objNetworkOperation.ClientIPaddress();
            var _HostName = objNetworkOperation.ClientHostName();
            var _ActionTime = DateConvertor.TimeNow();
            var _DateMiladi = DateConvertor.DateToNumber(DateConvertor.TodayDateMiladi());
            var _DateShamsi = DateConvertor.DateToNumber(DateConvertor.TodayDate());
            List<PostAction> PstAct = new List<PostAction>();
            PstAct.Add(new PostAction
            {
                ActionTime = _ActionTime,
                ActionTypeID = ActionTypeID,
                Browser = _Browser,
                Device = _Device,
                IP_Address = _IP_Address,
                HostName = _HostName,
                DateMiladi = _DateMiladi,
                DateShamsi = _DateShamsi,
                PostID = PostID
            });
            C_LikeViewList.NewLikeView(PstAct);
            SaveLog();
        }

        public void SaveLog()
        {
            if (C_LikeViewList.CompareListCreateTimeWithTimeNow())
            {
                var LstLikeView = C_LikeViewList.GetAllLikeView();
                if (LstLikeView.Count()
                    != 0)
                {
                    using (var _Context = new ApplicationDbContext())
                    {
                        var _objEntityActivity = new RepositoryPattern<Activity>(_Context);
                        foreach (var item in LstLikeView)
                        {
                            if (item.ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.View) || item.ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.Like) || item.ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.Downlaod))
                            {
                                var NewItem = new Activity
                                {
                                    ActionTime = item.ActionTime,
                                    DateMiladi = item.DateMiladi,
                                    DateShamsi = item.DateShamsi,
                                    ActivityTypeId = item.ActionTypeID,
                                    PostId = item.PostID,
                                    Browser = item.Browser,
                                    Device = item.Device,
                                    IP_Address = item.IP_Address,
                                    HostName = item.HostName,
                                    MoreInfo = ""
                                };
                                _objEntityActivity.Insert(NewItem);
                            }
                            else if (item.ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.DisLike))
                            {
                                var CurrItemDele = _objEntityActivity.GetByPredicate(x =>
                                     x.PostId == item.PostID
                                  && x.Browser == item.Browser
                                  && x.Device == item.Device
                                  && x.HostName == item.HostName
                                  && x.IP_Address == item.IP_Address
                                  && x.ActivityTypeId == Convert.ToInt32(EnumMethod.ActionType.Like));
                                if (CurrItemDele != null)
                                {
                                    _objEntityActivity.Delete(CurrItemDele.ID);
                                }

                            }
                        }
                        _objEntityActivity.Save();
                        _objEntityActivity.Dispose();
                        C_LikeViewList.ClearLikeViewList();
                    }
                }
            }
        }

        /// <summary>
        /// بررسی کاربر که اینکه مدیای جاری رو قبلا لایک کرده یا نه
        /// </summary>
        /// <returns></returns>
        /// 
        public bool CheckLastActionPost(int PostID, int ActivityType)
        {
            string CurrIP = objNetworkOperation.ClientIPaddress();
            string CurrHN = objNetworkOperation.ClientHostName();
            string CurrDT = objNetworkOperation.ClientDeviceType();
            string CurrBr = objNetworkOperation.ClientBrowser();
            using (var _Context = new ApplicationDbContext())
            {
                var _objEntityAction = new RepositoryPattern<Activity>(_Context);
                var PostLikeState = _objEntityAction.SearchFor(x =>
                x.Posts.ID == PostID &&
                x.IP_Address == CurrIP &&
                x.HostName == CurrHN &&
                x.Device == CurrDT &&
                x.Browser == CurrBr &&
                x.ActivityType.ID == ActivityType)
                .ToList()
                .LastOrDefault();

                if (PostLikeState != null)
                {
                    return true;
                }

            }
            //Search In RAM List
            var _LikeView = C_LikeViewList.GetAllLikeView();
            if (!(_LikeView == null || _LikeView.Count() == 0))
            {
                PostAction CurrItem = _LikeView.FirstOrDefault(x => 
                     x.PostID == PostID 
                  && x.Browser == CurrBr
                  && x.Device == CurrDT 
                  && x.HostName == CurrHN
                  && x.IP_Address == CurrIP 
                  && x.ActionTypeID == ActivityType);
                if (CurrItem != null)
                {
                    //در صورتي كه توي ليست (رم) باشد 
                    return true;
                }
            }
            return false;
        }
    }
}