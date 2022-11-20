using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(object request);
    }


    abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;

            // Returning a handler from here will let us link handlers in a covinent way

            return handler;
        }

        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return true;
            }
        }
    }

    class LengthHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string).Length<8)
            {
                return "To short";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class CaseHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            bool l = false;
            bool u = false;
            for (int i = 0; i < (request as string).Length; i++)
            {
                if((request as string)[i]>='a' && (request as string)[i] <= 'z')
                {
                    l= true;
                }
                if ((request as string)[i] >= 'A' && (request as string)[i] <= 'Z')
                {
                    u = true;
                }
            }
            if (!l || !u)
            {
                return "No lower and upper case letters";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class NumberHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            bool n = false;

            for (int i = 0; i < (request as string).Length; i++)
            {
                if ((request as string)[i] >= '0' && (request as string)[i] <= '9')
                {
                    n = true;
                    break;
                }
            }
            if (!n)
            {
                return "No numers";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
    class SpecialHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            bool s = false;
            string specialchars = "!#$%&'()*+-./:;<=>?@[]^_`{|}~";

            for (int i = 0; i < (request as string).Length; i++)
            {
                if(specialchars.Contains((request as string)[i]))
                {
                    s = true;
                    break;
                }
            }
            if (!s)
            {
                return "No special characters";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }



    class Client
    {
        // The client code is usually suited to work with a single handler. In
        // most cases, it is not even aware that the handler is part of a chain.
        public static void ClientCode(AbstractHandler handler)
        {
            Console.WriteLine("Set password:");
            string password = Console.ReadLine();
            var result = handler.Handle(password);
            if(result is bool)
            {
                Console.WriteLine("Correct password");
            }
            else
            {
                Console.WriteLine(result);
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The other part of the client code constructs the actual chain.
            var hlength = new LengthHandler();
            var hcase = new CaseHandler();
            var hnumer = new NumberHandler();
            var hspecial = new SpecialHandler();
            hlength.SetNext(hcase).SetNext(hnumer).SetNext(hspecial);
            Client.ClientCode(hlength);

        }
    }
}
