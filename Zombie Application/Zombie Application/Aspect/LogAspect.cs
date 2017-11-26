using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zombie_Application.ViewModels;

namespace Zombie_Application.Aspect
{
    [Serializable]
    public class LogAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            System.Diagnostics.Debug.WriteLine(Environment.NewLine);
            var arg0 = args.Arguments[0];

            var user = ((MovimentarViewModel)arg0).Usuario.Login;
            var Descricao = ((MovimentarViewModel)arg0).Descricao;
            var Quantidade = ((MovimentarViewModel)arg0).Quantidade; 
            var RecursoId = ((MovimentarViewModel)arg0).RecursoId;

            System.Diagnostics.Debug.WriteLine("O usuário "+user+" está movimentando a quantidade "+Quantidade+" do recurso "+RecursoId);

            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var arg0 = args.Arguments[0];

            var user = ((MovimentarViewModel)arg0).Usuario.Login;
            var Descricao = ((MovimentarViewModel)arg0).Descricao;
            var Quantidade = ((MovimentarViewModel)arg0).Quantidade;
            var RecursoId = ((MovimentarViewModel)arg0).RecursoId;

            System.Diagnostics.Debug.WriteLine("O usuário " + user + " movimentou a quantidade " + Quantidade + " do recurso " + RecursoId);

            base.OnExit(args);
        }
    }
}