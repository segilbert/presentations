﻿using System.Web;

namespace StriderCupRacing.Tests
{
    class StubContext : HttpContextBase
    {
        StubRequest request;

        public StubContext(string relativeUrl)
        {
            request = new StubRequest(relativeUrl);
        }

        public override HttpRequestBase Request
        {
            get { return request; }
        }
    }
}
