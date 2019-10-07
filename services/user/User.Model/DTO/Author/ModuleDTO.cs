using System;
using System.Collections.Generic;
using System.Text;
using User.Model.DAO;

namespace User.Model.DTO.Author
{
    /// <summary>
    /// 模块
    /// </summary>
    public class ModuleDTO : BaseDTO
    {
        public string LinkUrl { set; get; }

        public string Name { set; get; }

        public int Index { set; get; }


        public ModuleDTO Convert(ModuleDAO module)
        {
            if (module == null)
            {
                return null;
            }

            ModuleDTO dto = new ModuleDTO();

            dto.Id = module.MItemID;
            dto.Name = module.MName;
            dto.LinkUrl = module.MLink;
            dto.IsActive = module.MIsActive;
            dto.Index = module.MIndex;

            return dto;
        }


        public List<ModuleDTO> Convert(List<ModuleDAO> modules)
        {
            if(modules==null || modules.Count == 0)
            {
                return new List<ModuleDTO>();
            }

            var result = new List<ModuleDTO>();

            foreach(ModuleDAO module in modules)
            {
                ModuleDTO dto = Convert(module);

                if (dto != null)
                {
                    result.Add(dto);
                }
            }

            return result;
        }
    }
}
