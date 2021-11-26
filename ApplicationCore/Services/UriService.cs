using ApplicationCore.Services.Abstractions;
using ApplicationCore.Settings;
using System;

namespace ApplicationCore.Services
{
    public class UriService : IUriService
    {
        private readonly ProductSettings _productSettings;
        public UriService(ProductSettings productSettings)
        {
            _productSettings = productSettings;
        }

        public Uri GetProductPictureUri(string uriTemplate)
        {
            return new Uri(uriTemplate.Replace("", _productSettings.ProductImageBaseUri));
        }
    }
}
