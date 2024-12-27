# **Bat Fly**

![Google Play Badge](https://play.google.com/store/apps/details?id=com.AtesGames.com.unity.template.mobile2D)

![Project Demo](Gif/BatFly.gif)

Flappy Bird oyununun aynısını Unity üzerinde geliştirdim. Projenin temel amacı, Unity event sistemine hakim olmak ve aşağıdaki teknolojik becerileri geliştirmek:

- Asenkron programlama yapıları
- Tasarım desenleri (Design Patterns)
- Scriptable Object kullanımı
- Solid Prensipleri
- DOTween gibi eklentilerin entegrasyonu

Kısacası, Unity'de yazılım geliştirme becerilerimi standart bir seviyeye getirmek ve derinleştirmek.

## **Kullanılan Tasarım Desenleri**

### Command Pattern
**Kullanım Amacı:** Yapılan değişikliklerin kaydını tutmak ve gerektiğinde geri alınmasını sağlamak.

**Projede Kullanım Örneği:**
- Oyunun kullanıcı arayüzünde (UI) panel açma/kapama işlemlerinde uygulandı.

### Observer Pattern
**Tanım:** Bir gözetlenen nesne ve bir veya daha fazla gözetleyici arasındaki ilişkiyi yöneten desendir. Gözetlenen nesnede değişiklik olduğunda tüm gözetleyicilere anında bildirim yapılır.

**Projede Kullanım Örneği:** 
- Karakterin çarpışma algılayıcısı (Collider) başka bir nesneyle çarpıştığında (zemin, engeller vb.) tüm ilişkili bileşenlere otomatik bildirim gönderme.

### Singleton Pattern
**Tanım:** Bir sınıftan yalnızca bir nesne örneğinin oluşturulmasını ve bu örneğe global erişimi sağlayan desendir.

**Projede Kullanım Örneği:**
- Proje genelinde erişilmesi gereken merkezi yönetim sınıflarında uygulandı.

## **Kullanılan Teknikler ve Yaklaşımlar**

### Scriptable Objects
Unity'de veri yönetimi için kullanılan esnek bir yapı. Veriler komut dosyalarından bağımsız olarak depolanır ve editör üzerinden kolayca değiştirilebilir.

### Interface Kullanımı
- SOLID prensipleri gözetilerek farklı scriptler arasında tutarlı bir tür yönetimi sağlandı.
- Kod genişletilebilirliği ve bakımı için standartlar oluşturuldu.

### Unity Events
Olay yönetim sistemi, scriptler arası bağımsız iletişimi sağlayan önemli bir mekanizma.

**Avantajları:**
- Farklı script dosyaları birbirinden bağımsız çalışabilir
- Null reference hatalarını önler
- Daha esnek ve modüler kod yapısı sağlar

**Örnek Senaryo:**
Space tuşuna basıldığında karakterin zıplaması gerektiğinde, geleneksel yöntemler null reference hatası riski taşırken, event sistemi bu riski ortadan kaldırır.

## **Proje Mimarisi**

Projede her sınıf ve fonksiyon, yalnızca kendi sorumluluğunu yerine getirecek şekilde tasarlandı:

1. **Managers (Yöneticiler):**
   - Yalnızca görev dağılımından sorumlu
   - Herhangi bir direkt işlem yapmaz
   - Görevleri ilgili sınıflara iletir

2. **Controllers ve Commands (İşçiler):**
   - Managers tarafından verilen görevleri uygular
   - Gerekli araç ve sinyalleri kullanır

3. **Signals (Sinyaller):**
   - İşçiler ve Managers arasında bağlantı kurar
   - Görev iletişimini sağlar

4. **Event Yönetimi:**
   - Managers, SubscribeEvents ile olayları dinler
   - Görev tamamlandığında UnsubscribeEvents ile sistem temizlenir

## **Öğrenilen ve Pekiştirilen Konular**

- Design Pattern kullanım senaryoları
- Eklenti (Plugin) entegrasyonu
- Scriptable Object yapısı ve kullanımı
- Polimorfizmin pratik uygulamaları
- Asenkron programlamanın optimizasyona etkisi
- Unity Event sistemi
- Proje klasörleme standartları
- Struct ve Enum kullanım avantajları
- Merkezi kod yapısı ile karmaşıklığın azaltılması

## **Gereksinimler**

- Unity 2021.3.38f LTS veya üzeri bir sürüm
- DOTween Plugin
- .NET 4.x veya üzeri

## **Kurulum ve Çalıştırma**

1. Unity 2021.3.38f LTS veya üzeri bir sürüm gereklidir
2. Projeyi klonlayın
3. Unity Hub üzerinden projeyi açın
4. Gerekli paketlerin yüklenmesini bekleyin
5. Sahneyi çalıştırın
