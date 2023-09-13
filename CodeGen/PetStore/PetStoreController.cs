using PetStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.PetStore
{
    public class PetStoreController: PetStoreControllerBase
    {
        private readonly PetStoreDependency _petStoreDependency;

        public PetStoreController(PetStoreDependency petStoreDependency) 
        {
            _petStoreDependency = petStoreDependency;
        }

        protected async override Task<AddPetResponseBuilder> AddPetInternalAsync(Pet body)
        {
            return AddPetResponseBuilder.Build201();
        }
    }
}
