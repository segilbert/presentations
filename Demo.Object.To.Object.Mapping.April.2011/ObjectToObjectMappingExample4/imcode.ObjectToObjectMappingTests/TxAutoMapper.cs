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
using System.Linq;
//
using AutoMapper;
//
using NUnit.Framework;
//
using imcode.ObjectToObjectMapping.DTO;
using imcode.ObjectToObjectMapping.EditModels;
using imcode.ObjectToObjectMapping.Data;
using imcode.ObjectToObjectMapping.Domain;
using imcode.ObjectToObjectMapping.ViewModels;
using imcode.ObjectToObjectMapping.Mappings;

namespace imcode.ObjectToObjectMappingTests
{
    [TestFixture]
    public class TxAutoMapper
    {
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            // Configure AutoMapper
            CxMappings.SetupAutoMapper();
        }

        [Test]
        public void TestTrainToBrowseTrainsViewModel()
        {
            IxRepository repo = new CxTrainRepository();
            CxTrain train = repo.FindById<CxTrain>(4);
            var viewModel = Mapper.Map<CxTrain, CxBrowseTrainsViewModel>(train);

            Assert.AreEqual(train.Id,viewModel.Id);
            Assert.AreEqual(train.Name, viewModel.Name);
            Assert.AreEqual(string.Format("{0}, {1}", train.DefaultEngineer.LastName, train.DefaultEngineer.FirstName), viewModel.DefaultEngineerName);
            Assert.AreEqual("Y",viewModel.IsAwake);
        }

        [Test]
        public void TestTrainEditModelToTrain()
        {
            IxRepository repo = new CxTrainRepository();
            CxTrain train = repo.FindById<CxTrain>(4);
            CxTrainEditModel trainEditModel = Mapper.Map<CxTrain, CxTrainEditModel>(train);
            trainEditModel.IsAwake = "N";
            trainEditModel.Name = "Thomas The Train";

            var trainToSave = Mapper.Map<CxTrainEditModel, CxTrain>(trainEditModel);

            Assert.AreEqual(trainEditModel.Id, train.Id);
            Assert.AreEqual(trainEditModel.Id, trainToSave.Id);
            Assert.AreEqual(trainEditModel.Name, trainToSave.Name);
            Assert.AreEqual(false, trainToSave.IsAwake);
        }

        [Test]
        public void TestDynamicMap()
        {
            // Dynamic Mappings require no CreateMap setup
            // Assumes no custom resolver required to combine FirstName and LastName into Name
            // and properties need to be ignored
            CxEngineer engineer = new CxEngineer { Id=1,CallSign="Headless",FirstName="Horsemen",LastName="Headless"};
            CxEngineerViewModel engineerViewModel = Mapper.DynamicMap<CxEngineerViewModel>(engineer);

            Assert.AreEqual(engineer.Id,engineerViewModel.Id);
            Assert.AreEqual(engineer.CallSign, engineerViewModel.CallSign);
            Assert.AreEqual(engineer.FirstName, engineerViewModel.FirstName);
            Assert.AreEqual(engineer.LastName, engineerViewModel.LastName);
        }

        [Test]
        public void TestListOfTrainsToListOfTrainDTOMapping()
        {
            IList<CxTrain> trains = new CxTrainRepository().FindAll<CxTrain>();

            // Transform-Map
            IList<DxTrainDTO> trainDtos = Mapper.Map<IList<CxTrain>, IList<DxTrainDTO>>(trains);

            Assert.AreEqual(4, trainDtos.Count);

            for (int i = 0; i < trainDtos.Count; i++)
            {
                DxTrainDTO ds = trainDtos[i];
                CxTrain ts = trains[i];

                Assert.AreEqual(ts.Id, ds.Id);
                Assert.AreEqual(ts.Name, ds.Name);
                Assert.AreEqual(ts.Number, ds.Number);
            }
        }


        [Test]
        public void TestListOfLinesToListOfLineViewModelMapping()
        {
            IList<CxLine> lines  = new CxLineRepository().FindAll<CxLine>();

            // Transform-Map
            IList<CxLineViewModel> lineViewModels = Mapper.Map<IList<CxLine>, IList<CxLineViewModel>>(lines);

            Assert.AreEqual(3, lineViewModels.Count);

            for (int i = 0; i < lineViewModels.Count; i++)
            {
                CxLineViewModel ds = lineViewModels[i];
                CxLine ts = lines[i];

                Assert.AreEqual(ts.Id, ds.Id);
                Assert.AreEqual(ts.Name, ds.Name);
                Assert.AreEqual(ts.NumberOfSwitches, ds.NumberOfSwitches);

                // Nested Mapping for Location
                Assert.AreEqual(ts.Location.Id, ds.LocationId);
                Assert.AreEqual(ts.Location.AddressLine1, ds.LocationAddressLine1);
                Assert.AreEqual(ts.Location.City, ds.LocationCity);
                Assert.AreEqual(ts.Location.Country, ds.LocationCountry);
                Assert.AreEqual(ts.Location.Latitude, ds.LocationLatitude);
                Assert.AreEqual(ts.Location.Longitude, ds.LocationLongitude);
                Assert.AreEqual(ts.Location.PostalCode, ds.LocationPostalCode);
            }
        }


        [Test]
        public void TestIDataReaderToListOfLineDTOMapping()
        {
            IDataReader dr = new CxLineRepository().GetDataReader<CxLine>();

            try
            {

                // Transform-Map
                var lineDtos = Mapper.Map<IDataReader, IEnumerable<DxLineDTO>>(dr);

                dr.Close();

                Assert.IsNotNull(lineDtos);
                Assert.AreEqual(2, lineDtos.LongCount<DxLineDTO>());

                // Convert IEnumerable to IList using Linq
                IList<DxLineDTO> lineDtoList = lineDtos.ToList();

                Assert.IsNotNull(lineDtoList);
                Assert.AreEqual(2, lineDtoList.Count);

                // only get this for validation reasons
                dr = new CxLineRepository().GetDataReader<CxLine>();
                
                foreach (DxLineDTO s in lineDtoList)
                {
                    dr.Read();

                    Assert.AreEqual(dr[CxLineRepository.FieldNames.Id], s.Id);
                    Assert.AreEqual(dr[CxLineRepository.FieldNames.Name], s.Name);
                    Assert.AreEqual(dr[CxLineRepository.FieldNames.NumberOfSwitches], s.NumberOfSwitches);
                }

                dr.Close();

            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
        }
       
    }
}
