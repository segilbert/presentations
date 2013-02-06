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
using NUnit.Framework;
//
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
        }
    }
}
