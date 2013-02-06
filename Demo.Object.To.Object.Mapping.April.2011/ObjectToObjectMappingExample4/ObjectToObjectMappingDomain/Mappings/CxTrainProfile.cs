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
using imcode.ObjectToObjectMapping.Data;
using imcode.ObjectToObjectMapping.Domain;
using imcode.ObjectToObjectMapping.DTO;
using imcode.ObjectToObjectMapping.EditModels;
using imcode.ObjectToObjectMapping.ViewModels;

namespace imcode.ObjectToObjectMapping.Mappings
{
    public class CxTrainProfile : Profile   
    {
        protected override void Configure()
        {
            //               From Source - to Destination
            // Project CxTrain to destination CxBrowseTrainsViewModel
            CreateMap<CxTrain, CxBrowseTrainsViewModel>()
                .ForMember(d => d.DefaultEngineerName, opt => opt.ResolveUsing<EngineerNameResolver>())
                .ForMember(d => d.IsAwake, opt => opt.ResolveUsing<BooleanToDatabaseBooleanResolver>().FromMember(x => x.IsAwake));

            CreateMap<CxTrain, CxTrainEditModel>()
               .ForMember(d => d.IsAwake, opt => opt.ResolveUsing<BooleanToDatabaseBooleanResolver>().FromMember(x => x.IsAwake));

            CreateMap<CxTrainEditModel, CxTrain>()
                .ForMember(d => d.IsAwake,
                           opt => opt.ResolveUsing<DatabaseBooleanToBooleanResolver>().FromMember(x => x.IsAwake))
                .ForMember(d => d.Number, opt => opt.Ignore())
                .ForMember(d => d.DefaultEngineer, opt => opt.Ignore());
            //.ConvertUsing<CxTrainEditModelTrainConverter>();

            CreateMap<CxTrain, DxTrainDTO>()
                .ForMember(d => d.Code, opt => opt.Ignore())
                .ForMember(d => d.Description, opt => opt.Ignore())
                .ForMember(d => d.DescriptionOverride, opt => opt.Ignore());
        }
    }

    public class CxTrainEditModelTrainConverter : TypeConverter<CxTrainEditModel, CxTrain>
    {
        private readonly IxRepository repository;

        public CxTrainEditModelTrainConverter()
        {
            this.repository = new CxTrainRepository();
        }

        // IoC
        public CxTrainEditModelTrainConverter(IxRepository pxRepository)
        {
            this.repository = pxRepository;
        }

        protected override CxTrain ConvertCore(CxTrainEditModel source)
        {
            var train = repository.FindById<CxTrain>(source.Id);
            train.Name = source.Name;

            return train;
        }
    }
}
