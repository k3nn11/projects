using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logging
{
    public class Phone
    {

        private string _manufaturer;
        private string _model;
        public Phone(string manufacturer, string model) 
        {
            this._manufaturer = manufacturer;
            this._model = model;
            Log.Information("created {@phone} at {@now}",this,DateTime.Now);
        }
        public string Model {
            get
            {
                return _model;
            }
            set
            {
                if(value == null)
                {
                    Log.Error("The Model cannot be changed to null");
                }
                _model = value;
                Log.Information($"Model changed to {_model} at {DateTime.Now}");
                Log.Error("make sure the model corresponds to the {@phone}", this);
            
                
            }
        }
        public string Manufacturer
        {
            get
            {
                return this._manufaturer;
            }
            set
            {
                _manufaturer = value;
                Log.Information($"Manufaturer changed to {_manufaturer} at {DateTime.Now}");
                Log.Error("Make sure the Manufaturer corresponds to the model {@pone}", this);

            }
        }
    }
}
