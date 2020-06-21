using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using KlassenlisteService.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace KlassenlisteService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code:

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Klassenliste>("Klassenlistes");
            
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
            
        }
    }
}
