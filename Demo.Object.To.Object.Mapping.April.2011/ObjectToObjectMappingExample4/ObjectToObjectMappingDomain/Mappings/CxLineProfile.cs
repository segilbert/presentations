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
using System.Collections.Generic;
using System.Data;
//
using AutoMapper;
//
using imcode.ObjectToObjectMapping.Domain;
using imcode.ObjectToObjectMapping.DTO;
using imcode.ObjectToObjectMapping.ViewModels;

namespace imcode.ObjectToObjectMapping.Mappings
{
    public class CxLineProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CxLine, CxLineViewModel>();
            CreateMap<CxLine, DxLineDTO>()
                .ForMember(d => d.Code, opt => opt.Ignore())
                .ForMember(d => d.Description, opt => opt.Ignore())
                .ForMember(d => d.DescriptionOverride, opt => opt.Ignore());
            CreateMap<IDataReader, IEnumerable<DxLineDTO>>();

        }
    }
}
