//------------------ function return any Element in web--------------------
function _(el) {
    return document.getElementById(el);
}
//-----------------------Get Time Duration File MP3 or MP4------------------------
//reference
//https://developer.mozilla.org/en-US/docs/Web/API/FileReader/
//http://community.sitepoint.com/t/get-video-duration-before-upload/30623/4

//set your time on MaxTime like minutes:seconds
//if you wanna hours just replace below line on line 25
//var time = hours+':'minutes + ':' + seconds;

//maxTime = "01:00:00"; //if add a hours

var videoMaxTime = "60:00"; //minutes:seconds   //video
var audioMaxTime = "30:00"; //minutes:seconds   //audio
var uploadMax = 2000000000; //bytes  //30MP
//var uploadMax = 31457280; //bytes  //30MP
//for seconds to time
function secondsToTime(in_seconds) {
    var time = '';
    in_seconds = parseFloat(in_seconds.toFixed(2));

    var hours = Math.floor(in_seconds / 3600);
    var minutes = Math.floor((in_seconds - (hours * 3600)) / 60);
    var seconds = in_seconds - (hours * 3600) - (minutes * 60);
    //seconds = Math.floor( seconds );
    seconds = seconds.toFixed(0);

    if (hours < 10) {
        hours = "0" + hours;
    }
    if (minutes < 10) {
        minutes = "0" + minutes;
    }
    if (seconds < 10) {
        seconds = "0" + seconds;
    }
    var time = minutes + ':' + seconds;

    return time;

}

function SetFileDuration() {

    var file = document.querySelector('input[type=file]').files[0];
    //var file = $("#FileForUpload").get(0).files;
    var reader = new FileReader();
    var fileSize = file.size;
    //var getTime = '';
    if (fileSize > uploadMax) {
        bootbox.alert('اندازه فایل بسیار بزرگ است');
    } else {
        reader.onload = function (e) {
            // bootbox.alert("onload " + file.name);
            //if (file.type == "video/mp4" || file.type == "video/ogg" || file.type == "video/webm") {
            if (file.type == "video/mp4") {
                var videoElement = document.createElement('video');
                videoElement.src = e.target.result;
                var timer = setInterval(function () {
                    if (videoElement.readyState === 4) {
                        getTime = secondsToTime(videoElement.duration);
                        if (getTime > videoMaxTime) {
                            bootbox.alert(" مدت زمان ویدیو حداکثر " + videoMaxTime + " دقیقه باشد ");
                        }
                        clearInterval(timer);
                    }
                }, 500)
            }
                ///else if (file.type == "audio/mpeg" || file.type == "audio/wav" || file.type == "audio/ogg") {
            else if (file.type == "audio/mp3") {
                var audioElement = document.createElement('audio');
                audioElement.src = e.target.result;
                var timer = setInterval(function () {
                    if (audioElement.readyState === 4) {
                        getTime = secondsToTime(audioElement.duration);
                        if (getTime > audioMaxTime) {
                            bootbox.alert(" مدت زمان فایل صوتی حداکثر " + videoMaxTime + " دقیقه باشد ");
                        }
                        clearInterval(timer);
                    }
                }, 500)
            } else {
                var timer = setInterval(function () {
                    if (file) {
                        clearInterval(timer);
                    }
                }, 500)
            }
        };
        if (file) {
            reader.readAsDataURL(file);
            
        }
        else {
            bootbox.alert('فایلی وجود ندارد');
        }
    }
    return getTime;
}

//---------------------upload-------------
function progressHandler(event) {
    //_("loaded_n_total").innerHTML = "Uploaded " + formatFileSize(event.loaded) + " of " + formatFileSize(event.total);
    _("loaded_n_total").innerHTML =  formatFileSize(event.loaded) + "    از    " + formatFileSize(event.total)+ "   بارگذاری شده    ";
    var percent = (event.loaded / event.total) * 100;
    _("progressBar").value = Math.round(percent);
    //_("status").innerHTML = Math.round(percent) + "% uploaded... please wait";
    _("status").innerHTML =" "+ Math.round(percent) + "% بارگذاری شده... لطفا منتظر بمانید  ";
}

function completeHandler(event) {
    _("status").innerHTML = event.target.responseText;
    _("progressBar").value = 0; //wil clear progress bar after successful upload
    $('#progressBar').hide();
    $('#loaded_n_total').hide();
    document.getElementById("h4ModalID").innerHTML = "پایان بارگذاری";
    ShowCloseButton();
   
}

function errorHandler(event) {
    //_("status").innerHTML = "Upload Failed";
    _("status").innerHTML = "خطا در بارگذاری";
}

function abortHandler(event) {
    //_("status").innerHTML = "Upload Aborted";
    _("status").innerHTML = "لغو بارگذاری";
}

function ShowUploadModal() {
    $('#UploadModal').modal({ backdrop: 'static', keyboard: false })
    //$('#modal_footerID').hide();
    $('#ModalSubmitButton').hide();
    $('#ModalCancelButton').show();
    hideCloseButton();

}
function hideCloseButton() {
    // get the close button inside the modal
    $('#UploadModal .close').css('display', 'none');
}
function ShowCloseButton() {
    // get the close button inside the modal
    $('#UploadModal .close').css('display', 'inline');
    $('#ModalSubmitButton').show();
    $('#ModalCancelButton').hide();
}

//---------------------Get Size of File-------------
function formatFileSize(bytes) {
    decimalPoint = 2;
    if (bytes == 0) return '0 Bytes';
    var k = 1000,
        dm = decimalPoint || 2,
        sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'],
        i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
}
//---------------- GetExtention File ----------------
function getFileExtension1(filename) {
    return (/[.]/.exec(filename)) ? /[^.]+$/.exec(filename)[0] : undefined;
}
function getFileExtension2(filename) {
    return filename.split('.').pop();
}
function getFileExtension3(filename) {
    return filename.slice((filename.lastIndexOf(".") - 1 >>> 0) + 2);
}
//--------------------------------------------