using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Abstractions
{
    public interface IUriService
    {

        public Uri GetProductPictureUri(string uriTemplate);
    }
}
