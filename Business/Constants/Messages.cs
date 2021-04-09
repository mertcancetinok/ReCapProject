using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarListed = "Arabalar listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorListed = "Renkler listelendi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandListed = "Markalar listelendi";

        public static string RentalAdded = "Araç kiralandı";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalListed = "Kiralamalar listelendi";
        public static string CarIsNotReturn = "Araç şuan kirada";

        public static string CarImageAdded = "Araba'ya resim eklendi";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImageUpdate = "Resim silindi";
        public static string CarImagesMoreThanFive = "Arabanın resim sayısı 5'ten fazla olamaz";

        public static string AccessTokenCreated = "Erişim tokenı oluşturuldu";
        public static string UserAlreadyExists = "Böyle bir kullanıcı var";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserRegistered = "Başarıyla kayıt olundu";

        public static string AuthorizationDenied = "Erişim yetkisi yok";
    }
}
