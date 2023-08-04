# PartialView and View Components

# Partial View

Partial View, bir MVC (Model-View-Controller) uygulamasında kullanıcı arayüzünün bir parçasını oluşturan küçük, bağımsız bir view parçasıdır. Bu view, diğer view'larda kullanılmak üzere tekrar kullanılabilir. Yani, kod tekrarını önlemek ve view dosyalarını daha modüler hale getirmek için kullanılır. Partial view'lar, ".cshtml" uzantılı dosyalarda yazılır ve view'ın küçük parçalarını oluştururken view içinde yer alan Razor kodlarından faydalanabilir. Partial view, View veya Controller ile bir modeli paylaşabilir ve bu modeli kullanarak içeriğini dinamik olarak oluşturabilir.

# View Component

View Component, .NET Core MVC'de kısmi view'lardan daha gelişmiş bir yapıdır. View Component, bir view parçasını ve ilgili iş mantığını içeren bağımsız bir bileşendir. Yani, kendi bağımsız action'ları ve view'ları vardır. View Component'ler, daha karmaşık ve tekrar kullanılabilir componentler oluşturmak için kullanılır. Bir View Component, küçük ve özel bir görevi yerine getirir ve daha büyük bir view veya layout içinde yer alabilir. View Component, Razor kodunu içeren ".cshtml" uzantılı bir view ve bu view'u çalıştıran C# kodundan oluşur. Bir View Component, bir Controller'dan bağımsız olarak çalışır ve kendisine ait bir view dosyasını render eder.

## Özetle

- **Partial View**: Küçük, tekrar kullanılabilir bir view parçasıdır ve kendi başına çalışamaz.

- **View Component**: Bağımsız bir bileşen olarak çalışan ve kendi action ve view'larına sahip olan bir view bileşenidir.

Bu yapılar, MVC projelerinde UI bileşenlerini oluştururken kodun tekrarını önlemeye, kodu daha düzenli ve modüler hale getirmeye yardımcı olur. Hangi yapıyı kullanacağınız projenizin ihtiyaçlarına ve UI tasarımınıza bağlıdır.

