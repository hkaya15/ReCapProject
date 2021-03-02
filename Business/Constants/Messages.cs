using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarNameAndPriceInvalid = "Araç eklendi";
        public static string OutUse = "Mesai saatleri dışındasın. Sistem kullanım dışı";
        public static string CarListed = "Araç Listelendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarDetailed = "Araç detaylandırıldı";
        public static string CarUpdated = "Araç güncellendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorAdded = "Renk eklendi";
        public static string RentalAdded = "Kiralama işlemi başarılı";
        public static string ImagesAdded = "Fotoğraf eklendi";
        public static string FailAddedImageLimit = "Fotoğraf ekleyemezsiniz limite ulaşıldı";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı Kayıt Oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatası";
        public static string SuccessfulLogin = "Başarılı giriş yapıldı";
        public static string UserAlreadyExists = "Bu kullanıcı var";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
