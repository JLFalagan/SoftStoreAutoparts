using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    public static class EventHandlerExtensions
    {
        public static void SafeInvoke(this EventHandler evt, object sender, EventArgs evtArgs)
        {
            if (evt != null)
            {
                evt(sender, evtArgs);

                //try
                //{
                //    evt(sender, evtArgs);
                //}
                //catch (Exception e)
                //{
                //    //CTX.CM.Log().Error(e, e.Message);

                //    //if (AppInfo.Application != null)
                //    //    AppInfo.Application.UnexpectedExceptionHandler.Handle(evt, e);
                //    //else
                //    throw;
                //}
            }
        }

        public static void SafeInvoke<T>(this EventHandler<T> evt, object sender, T evtArgs) where T : EventArgs
        {
            if (evt != null)
            {
                evt(sender, evtArgs);
                //try
                //{
                //    evt(sender, evtArgs);
                //}
                //catch (Exception e)
                //{
                //    //  CTX.CM.Log().Error(e, e.Message);

                //    //if (AppInfo.Application != null)
                //    //    AppInfo.Application.UnexpectedExceptionHandler.Handle(evt, e);
                //    //else
                //    throw;

                //}

            }
        }
    }
}
