using System;
using System.Collections.Generic;
using SFDL;
using SFModels;

namespace SFBL
{


    public class Line_ItemBL :ILine_ItemBL
    {
        private ILRepository _repo;
        /// <summary>
        /// We are defining the dependencies this class needs to operate
        /// We do it this way because we can easily switch out which implementation details we will be using
        /// But later on the lecture, we can then switch our SFDL project to point to an actual database in the cloud and we don't have to touch anything else to
        /// have the implementation
        /// </summary>
        /// <param name="p_repo">It will pass in a Respository object</param>
        public Line_ItemBL(ILRepository p_repo)
        {
            _repo = p_repo;
        }

        public Line_Item GetLine_ItemByID(int l_item)
        {
            Line_Item lineFound = _repo.GetLine_ItemByID(l_item);

            if (lineFound == null)
            {
                throw new Exception("LineItem was not found");
            }

            return lineFound;
        }

        public List<Line_Item> GetAllLine_Items(int StoreID)
        {
            return _repo.GetAllLine_Items(StoreID);
        }
    }
}