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
                .ForMember( d => d.DefaultEngineerName, 
                            opt => opt.MapFrom( s => string.Format("{0}, {1}", 
                                                            s.DefaultEngineer.LastName, 
                                                            s.DefaultEngineer.FirstName)));

            // Validate All Is Good
            Mapper.AssertConfigurationIsValid();
        }
    }
}
