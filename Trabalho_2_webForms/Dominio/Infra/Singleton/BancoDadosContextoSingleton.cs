﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho_2_webForms.Dominio.Context;

namespace Trabalho_2_webForms.Dominio.Infra.Singleton
{
    public static class BancoDadosContextoSingleton
    {
        public static BancoDadosContexto BancoDados = new BancoDadosContexto();
    }
}