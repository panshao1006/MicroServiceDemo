using Organization.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.ViewModel
{
    public class OrganizationViewModel
    {
        public string Id { set; get; }

        public string Name { set; get; }

        public DateTime ExpireDate { set; get; }


        public OrganizationViewModel ConvertViewModel(OrganizationModel organzition)
        {
            if(organzition == null)
            {
                return null;
            }

            OrganizationViewModel result = new OrganizationViewModel();
            result.Id = organzition.MItemID;
            result.Name = organzition.MName;

            return result;
        }


        public List<OrganizationViewModel> ConvertViewModel(List<OrganizationModel> organzitions)
        {
            List<OrganizationViewModel> result = new List<OrganizationViewModel>();

            foreach(OrganizationModel organization in organzitions)
            {
                OrganizationViewModel viewModel = ConvertViewModel(organization);

                if (viewModel == null)
                {
                    continue;
                }

                result.Add(viewModel);
            }


            return result;
        }
    }
}
