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
using AutoMapper;
//
using imcode.ObjectToObjectMapping.Domain;
using imcode.ObjectToObjectMapping.ViewModels;

namespace imcode.ObjectToObjectMapping.Mappings
{
    public class CxMappings
    {
        public static void SetupAutoMapper()
        {
             // Configure AutoMapper
            //
            //               From Source - to Destination
            // Project CxTrain to destination CxBrowseTrainsViewModel
            Mapper.CreateMap<CxTrain, CxBrowseTrainsViewModel>()
                .ForMember(d => d.DefaultEngineerName, opt => opt.ResolveUsing<EngineerNameResolver>())
                .ForMember(d => d.IsAwake, opt => opt.ResolveUsing<BooleanToDatabaseBooleanResolver>().FromMember(x => x.IsAwake));

            // Validate All Is Good
            Mapper.AssertConfigurationIsValid();
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
