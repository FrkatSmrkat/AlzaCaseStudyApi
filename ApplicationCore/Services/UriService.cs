using ApplicationCore.Services.Abstractions;
using ApplicationCore.Settings;
using Microsoft.Extensions.Options;
using System;

namespace ApplicationCore.Services
{
    public class UriService : IUriService
    {
        private readonly ProductSettings _productSettings;
        private readonly string FAKE_URI = "fakeUri";
        public UriService(IOptions<ProductSettings> productSettings)
        {
            _productSettings = productSettings.Value;
        }

        public Uri GetProductPictureUri(string uriTemplate)
        {
            return new Uri(uriTemplate.Replace(FAKE_URI, _productSettings.ProductImageBaseUri));
        }
    }
}
