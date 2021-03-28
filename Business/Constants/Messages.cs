using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string EntityAdded = "Nesne eklendi";
        public static string EntityUpdated = "Nesne güncellendi";
        public static string EntityDeleted = "Nesne silindi";
        public static string EntityNameInvalid = "Nesne adı geçersiz";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kaydı oluşturuldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı parola";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Giriş anahtarı oluşturuldu";
        //RENTAL MESSAGES
        public static string CarIsNotAvailable = "Araç kiralanmaya uygun değil";
        public static string ImagesLimitExceeded = "Araca en fazla 5 resim yükleyebilirsiniz";
        public static string ImageNotFound = "Araca ait resim bulunamadı";
    }
}
