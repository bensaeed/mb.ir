using mbensaeed.Helper;
using mbensaeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.OpratingClasses
{
    static class C_LikeViewList
    {
        /// <summary>
        /// زمان ايجاد ليست لايك ها و ويوها جهت ذخير در ديتابيس
        /// </summary>

        static DateTime TimeListCreateTime;
        public static void SetListCreateTime() => TimeListCreateTime = DateConvertor.TimeNowFull();

        public static DateTime RetListCreateTime()
        {
            return TimeListCreateTime;
        }
        public static bool CompareListCreateTimeWithTimeNow()
        {
            //int i = DateTime.Compare(t1, t2);
            //if t1 is less than t2 then result is Less than zero
            //if t1 equals t2 then result is Zero
            //if t1 is greater than t2 then result isGreater zero

            int cmp = DateTime.Compare(DateConvertor.TimeNowFull(), Convert.ToDateTime(RetListCreateTime().AddMinutes(1)));
            if (cmp > 0)
                return true;
            return false;
        }

        static List<PostAction> _LikeView;
        static C_LikeViewList()
        {
            _LikeView = new List<PostAction>();
        }
        public static void NewLikeView(IEnumerable<PostAction> postActions)
        {
            if (!(postActions is null))
            {
                var ls = postActions.FirstOrDefault();
                if (ls.ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.View) || ls.ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.Like) || ls.ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.Downlaod))
                {
                    AddViewLike(postActions);
                }
                else if (ls.ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.DisLike))
                {
                    if (!(_LikeView == null || _LikeView.Count() == 0))
                    {
                        PostAction CurrItem = _LikeView.FirstOrDefault(x => x.PostID == ls.PostID && x.Browser == ls.Browser
                          && x.Device == ls.Device && x.HostName == ls.HostName
                          && x.IP_Address == ls.IP_Address && x.ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.Like));
                        if (CurrItem != null)
                        {
                            //در صورتي كه توي ليست (رم) باشد 
                            _LikeView.Remove(CurrItem);
                        }
                        else
                        {
                            //در صورتي كه ليست ايجاد شده باشد - اضافه ميكند به ليست موجود
                            AddViewLike(postActions);
                        }
                    }
                    else
                    {
                        AddViewLike(postActions);
                    }
                }

            }
        }
        public static void AddViewLike(IEnumerable<PostAction> postActions)
        {
            if (!(postActions is null))
            {
                var ls = postActions.FirstOrDefault();
                if (_LikeView == null || _LikeView.Count() == 0)
                {
                    SetListCreateTime();
                }
                var lst = new PostAction
                {
                    PostID = ls.PostID,
                    Browser = ls.Browser,
                    Device = ls.Device,
                    HostName = ls.HostName,
                    IP_Address = ls.IP_Address,
                    ActionTypeID = ls.ActionTypeID,
                    ActionTime = ls.ActionTime,
                    DateMiladi = ls.DateMiladi,
                    DateShamsi = ls.DateShamsi,
                    MoreInfo = ""
                };
                _LikeView.Add(lst);
            }
        }
        //public static void RemoveViewLike(int _PostID, string _Browser, string _Device,
        //    string _HostName, string _IP_Address, int _ActionTypeID) 
        public static void RemoveViewLike(IEnumerable<PostAction> postActions)
        {
            if (!(postActions is null))
            {
                var ls = postActions.FirstOrDefault();
                if (!(_LikeView == null || _LikeView.Count() == 0))
                {
                    var CurrItem = _LikeView.Single(x => x.PostID == ls.PostID && x.Browser == ls.Browser
                      && x.Device == ls.Device && x.HostName == ls.HostName
                      && x.IP_Address == ls.IP_Address && x.ActionTypeID == ls.ActionTypeID);

                    _LikeView.Remove(CurrItem);
                }
                else
                {
                    //
                }
            }
        }
        public static List<PostAction> GetAllLikeView()
        {
            return _LikeView;
        }
        public static void ClearLikeViewList()
        {
            _LikeView.Clear();
        }
    }
}