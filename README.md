# 🌿 Kişisel Portfolyo & Yönetim Paneli

ASP.NET Core MVC ile geliştirilmiş, tamamen veritabanından beslenen kişisel portfolyo sitesi ve içeriği yöneten **Admin Paneli**.
Ana sitedeki tüm bölümler (Hakkımda, Yetenekler, Deneyim, Projeler, Eğitim, İletişim) admin panelinden yönetilir; ziyaretçilerin gönderdiği mesajlar panelde toplanır.

> **M&Y Yazılım Eğitim Akademi · 12. Dönem Gündüz Grubu · Portfolyo Projesi**
> Geliştirici: **Hasret Nisa Enginer**

---

## 📸 Ekran Görüntüleri

| Ana Sayfa 

<img width="1872" height="908" alt="Ekran görüntüsü 2026-11-07 234257" src="https://github.com/user-attachments/assets/49285ad8-001a-40b1-8a16-40671c2ff2ff" />

<img width="1876" height="905" alt="Ekran görüntüsü 2026-11-07 234854" src="https://github.com/user-attachments/assets/4fdda7c1-86a8-488d-b721-396ad794efb4" />

<img width="1852" height="892" alt="Ekran görüntüsü 2026-11-07 234909" src="https://github.com/user-attachments/assets/2a0dd034-dc36-4381-a9c1-471e9164dc82" />

<img width="1712" height="850" alt="Ekran görüntüsü 2026-11-07 234926" src="https://github.com/user-attachments/assets/a4136916-d900-49a8-a8de-4f98a2231a7a" />

<img width="1835" height="852" alt="Ekran görüntüsü 2026-11-07 234940" src="https://github.com/user-attachments/assets/e37bf846-62a9-4705-848f-b868bde0ada7" />

<img width="1872" height="717" alt="Ekran görüntüsü 2026-11-07 234948" src="https://github.com/user-attachments/assets/2bab51d5-1a5c-4921-a5af-305314f50809" />

<img width="1872" height="897" alt="Ekran görüntüsü 2026-11-07 235007" src="https://github.com/user-attachments/assets/78bdaf13-ea50-4499-be4e-59939e5ef80c" />

<img width="1866" height="822" alt="Ekran görüntüsü 2026-11-07 235131" src="https://github.com/user-attachments/assets/d5360218-da53-49ac-8759-bff25aff0345" />

| Proje Yönetimi | Admin Panel

<img width="1875" height="882" alt="Ekran görüntüsü 2026-11-07 235200" src="https://github.com/user-attachments/assets/75ad0fcf-4014-4fb1-aaf0-11db21a5b066" />

<img width="1885" height="907" alt="Ekran görüntüsü 2026-11-07 235214" src="https://github.com/user-attachments/assets/e060c35f-fe7d-46c0-b668-1f4758721edf" />

<img width="1882" height="882" alt="Ekran görüntüsü 2026-11-07 235223" src="https://github.com/user-attachments/assets/b9e31eb2-a7fc-4a29-abc6-12f5802384d1" />

<img width="1890" height="837" alt="Ekran görüntüsü 2026-11-07 235227" src="https://github.com/user-attachments/assets/bc05b18e-2001-47da-9bdc-1c6eafa52493" />

<img width="1877" height="912" alt="Ekran görüntüsü 2026-11-07 235231" src="https://github.com/user-attachments/assets/c8983ca1-6ac9-4bb6-a009-c835bed146ee" />

<img width="1882" height="907" alt="Ekran görüntüsü 2026-11-07 235236" src="https://github.com/user-attachments/assets/0e2eb5b3-69b6-4fc1-b190-c1a60e0d8fd5" />

<img width="1892" height="810" alt="Ekran görüntüsü 2026-11-07 235243" src="https://github.com/user-attachments/assets/7ba91ede-8944-45f2-a8a3-527abefbe8b4" />

<img width="1886" height="765" alt="Ekran görüntüsü 2026-11-07 235250" src="https://github.com/user-attachments/assets/f026ee87-4084-4f80-8c04-ae10e63d1398" />

---

## ✨ Özellikler

### 🌐 Ziyaretçi Sitesi
- Veritabanından dinamik içerik: Hakkımda, Yetenekler (seviye çubuklarıyla), Deneyim, Eğitim, Projeler, İletişim
- **Proje filtreleme:** Kategorilere göre anında filtreleme (kategoriler veritabanından gelir)
- Yalnızca **aktif** projeler yayınlanır; proje görseli, teknolojiler ve proje bağlantısı gösterilir
- **İletişim formu:** Gönderilen mesaj `Message` tablosuna kaydedilir, başarı/hata bildirimi gösterilir
- Sosyal medya bağlantıları (GitHub, LinkedIn, Instagram, YouTube) admin panelinden yönetilir
- Responsive tasarım (Bootstrap 5)

### 🛠️ Admin Paneli (`Areas/Admin`)
| Modül | Özellikler |
|---|---|
| **Dashboard** | `DashboardViewModel` ile dinamik istatistikler: toplam/aktif proje, yetenek, deneyim, eğitim ve mesaj sayıları, okunma oranı, son 7 günlük mesaj grafiği, kategoriye göre proje dağılımı, son 3 proje, son 5 mesaj, hızlı erişim butonları |
| **Projeler** | CRUD, **görsel yükleme (IFormFile)**, kategori seçimi (dropdown), kategori filtresi, sıralama, Aktif/Pasif durumu |
| **Kategoriler** | CRUD |
| **Yetenekler** | CRUD, 0-100 seviye doğrulaması, ilerleme çubuğu |
| **Yetenek Öğeleri** | CRUD, yeteneğe bağlı (dropdown) |
| **Deneyim** | CRUD, hızlı ekleme paneli, arama / filtre / sıralama / CSV dışa aktarma |
| **Eğitim** | CRUD |
| **Hakkımda** | CRUD |
| **İletişim** | CRUD, sosyal medya bağlantıları |
| **Mesajlar** | Mesaj detayı modalı, okundu/okunmadı durumu, arama, sıralama, **okunmamış mesaj rozeti** (sidebar), silme |

### ✅ Genel
- **Data Annotations** + `ModelState.IsValid` ile sunucu taraflı doğrulama, Türkçe hata mesajları
- Görsel yüklemede **uzantı ve boyut kontrolü**, benzersiz (GUID) dosya adı, veritabanında yalnızca dosya yolu
- **SweetAlert2** silme onayı ve toast bildirimleri (`AdminNotificationFilter` ile merkezi yönetim)
- Başarı/hata bildirimleri için **PRG (Post-Redirect-Get)** deseni ve `TempData`
- **View Component** mimarisiyle parçalı ana sayfa

---

## 🧱 Kullanılan Teknolojiler

- **Backend:** ASP.NET Core MVC, C#, Areas, View Components, Action Filters
- **Veri:** Entity Framework Core (Code First, Migrations), SQL Server
- **Frontend:** Razor, Bootstrap 5, Bootstrap Icons, SweetAlert2, Vanilla JavaScript
- **Araçlar:** Visual Studio, Git & GitHub

## 🗂️ Proje Yapısı

```
MYAcademy_PortfolioProject
├── Areas/Admin
│   ├── Controllers        # Admin CRUD controller'ları
│   └── Views              # Admin sayfaları ve layout/sidebar component'leri
├── Context                # PortfolioContext (EF Core DbContext)
├── Controllers            # Ana site (DefaultController)
├── Entities               # Veri modelleri (Project, Skill, Message, ...)
├── Filters                # AdminNotificationFilter
├── Migrations
├── ViewModels             # DashboardViewModel
├── Views                  # Ana site görünümleri ve View Component'ler
└── wwwroot                # Statik dosyalar ve yüklenen görseller (uploads)
```

## 🚀 Kurulum

### Gereksinimler
- [.NET SDK](https://dotnet.microsoft.com/download) (projenin hedeflediği sürüm)
- SQL Server (LocalDB ya da SQL Server Express yeterli)
- Visual Studio 2022 (önerilir)

### Adımlar

1. **Projeyi klonlayın**
   ```bash
   git clone https://github.com/hasretenginrr/MYAcademy_PortfolioProject.git
   cd REPO_ADI
   ```

2. **Bağlantı dizesini ayarlayın** — `PortfolioContext.cs` (ya da `appsettings.json`) içindeki sunucu adını kendi SQL Server'ınıza göre düzenleyin:
   ```
   Server=.;Database=PortfolioDayDb;Trusted_Connection=True;TrustServerCertificate=True;
   ```

3. **Veritabanını oluşturun** (Package Manager Console):
   ```
   Update-Database
   ```
   veya terminalden:
   ```bash
   dotnet ef database update
   ```

4. **Projeyi çalıştırın** (`F5` veya `dotnet run`)

5. **Adresler**
   | Sayfa | Adres |
   |---|---|
   | Ana site | `/Default/Index` |
   | Admin paneli | `/Admin/Dashboard/Index` |

> 💡 İlk çalıştırmada tablolar boş gelir. Admin panelinden kategori, proje, yetenek vb. ekleyerek siteyi doldurabilirsiniz.

---

## 🔒 Doğrulama ve Güvenlik Notları

- Formlarda `[Required]`, `[StringLength]`, `[EmailAddress]`, `[Url]`, `[Range]` gibi Data Annotations kullanılır.
- İletişim formu ve admin formları `ValidateAntiForgeryToken` / tag helper token'ları ile korunur.
- Yüklenen dosyalar yalnızca izin verilen uzantılar ve boyut sınırıyla kabul edilir.

## 💡 Özgün Katkılar

Case gereksinimlerinin ötesinde eklenen özellikler:

1. **Merkezi bildirim sistemi:** `AdminNotificationFilter` ile tüm Ekle/Güncelle/Sil işlemleri için otomatik başarı mesajı ve hata yakalama; her controller'a ayrı kod yazmadan çalışır.
2. **SweetAlert2 silme onayı:** Mevcut `confirm()` metinleri korunarak tüm silme linklerine tek noktadan uygulanan modern onay penceresi.
3. **Zengin Dashboard:** Son 7 günün mesaj grafiği, okunma oranı halkası, kategori dağılımı ve son projeler; tamamı gerçek veriyle (`GroupBy`, `OrderByDescending`, `Take`).
4. **Mesaj kutusu deneyimi:** Modal ile mesaj okuma, açılışta otomatik okundu işaretleme, okunmamış mesaj sayısının sidebar rozetinde canlı gösterimi.
5. **Aktif menü vurgusu ve null-güvenli ortak script:** Sidebar'da bulunulan sayfa otomatik işaretlenir; tüm admin sayfalarında çalışan tek script dosyası.
6. **Deneyim tablosunda istemci taraflı arama, filtre, sıralama ve CSV dışa aktarma.**
7. **Sosyal medya bağlantılarının admin panelinden yönetilmesi;** boş bırakılan bağlantı ana sitede otomatik gizlenir.

-Hasret Nisa Enginer-


