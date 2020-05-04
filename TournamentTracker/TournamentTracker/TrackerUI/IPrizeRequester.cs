using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerUI
{
    // this interface allows us to be loosely coupled since anyone can implement this 
    // the prize form doesn't know who we are it just knows we implement this interface
    // the tournament form does know cause it needs to know what instance to call
    public interface IPrizeRequester
    {        
        void PrizeComplete(PrizeModel model);
    }
}
