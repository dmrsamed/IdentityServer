using IdentityServer4.Models;

namespace Identity.MobilApi;

public static class Config
{
    public static IEnumerable<ApiResource> GetApiResource()
    {
        return new List<ApiResource>()
        {
            new ApiResource("iq_api") {Scopes = {"iqapi.read", "iqapi.write", "iqapi.update"},ApiSecrets = new[] {new Secret("iqapisecret".Sha256())}},
            new ApiResource("mobil_api") {Scopes = {"mobilapi.read", "mobilapi.write", "mobilapi.update"},ApiSecrets = new[] {new Secret("mobilapisecret".Sha256())}},
        };
    }

    public static IEnumerable<ApiScope> GetApiScope()
    {
        return new List<ApiScope>()
        {
            new ApiScope("iqapi.read", "Iq Apisi İçin Okuma izni"),
            new ApiScope("iqapi.write", "Iq Apisi İçin yazma izni"),
            new ApiScope("iqapi.update", "Iq Apisi İçin güncelleme izni"),

            new ApiScope("mobilapi.read", "Iq Apisi İçin Okuma izni"),
            new ApiScope("mobilapi.write", "Iq Apisi İçin yazma izni"),
            new ApiScope("mobilapi.update", "Iq Apisi İçin güncelleme izni")
        };
    }

    public static IEnumerable<Client> GetClient()
    {
        return new List<Client>
        {
            new Client()
            {
                ClientName = "Iq Clienti",
                ClientId = "Client1",
                ClientSecrets = new[] {new Secret("iqsecret".Sha256())}, //Client Secreti Şifreleniyor
                AllowedGrantTypes = GrantTypes.ClientCredentials, //UserPassword Olmadan Giriş Yapılıyor
                AllowedScopes = new[] {"iqapi.read"}, //Hangi izinlere sahip olduğunu belirtir
            },
            new Client()
            {
                ClientName = "Mobil Clienti",
                ClientId = "Client2",
                ClientSecrets = new[] {new Secret("mobilsecret".Sha256())}, //Client Secreti Şifreleniyor
                AllowedGrantTypes = GrantTypes.ClientCredentials, //UserPassword Olmadan Giriş Yapılıyor
                AllowedScopes = new[] {"iqapi.read","iqapi.write", "mobilapi.read"}, //Hangi izinlere sahip olduğunu belirtir
            }
        };
    }
}