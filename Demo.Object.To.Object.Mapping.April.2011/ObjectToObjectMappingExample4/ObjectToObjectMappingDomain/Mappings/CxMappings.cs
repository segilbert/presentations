#region license

/*
Copyright 2011 Sean Gilbert

Dual licensed under the MIT or GPL Version 2 licenses.

Unless required by applicable law or agreed to in writing, software 
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/

#endregion
//
using System;
//
using AutoMapper;
//
using imcode.ObjectToObjectMapping.Domain;

namespace imcode.ObjectToObjectMapping.Mappings
{
    public class CxMappings
    {
        public static void SetupAutoMapper()
        {
            // Configure AutoMapper
            Mapper.AddProfile(new CxTrainProfile());     
            Mapper.AddProfile(new CxLineProfile());

            // Validate All Is Good
            Mapper.AssertConfigurationIsValid();
        }
    }

    public class UtcDateFormatter : IValueFormatter
    {   
        public string FormatValue(ResolutionContext context)
        {
            return (!context.IsSourceValueNull ? ((DateTime)context.SourceValue).ToUniversalTime().ToLongDateString() : string.Empty);
        }
    }

    public class EngineerNameResolver : ValueResolver<CxTrain, string>
    {
        protected override string ResolveCore(CxTrain source)
        {
            return string.Format("{0}, {1}", source.DefaultEngineer.LastName, source.DefaultEngineer.FirstName);
        }
    }

    public class BooleanToDatabaseBooleanResolver : ValueResolver<bool, string>
    {
        protected override string ResolveCore(bool source)
        {
            return source ? "Y" : "N";
        }
    }

    public class DatabaseBooleanToBooleanResolver : ValueResolver<string, bool>
    {
        protected override bool ResolveCore(string source)
        {
            return source.ToUpper().Equals("Y") ? true : false;
        }
    }
}
