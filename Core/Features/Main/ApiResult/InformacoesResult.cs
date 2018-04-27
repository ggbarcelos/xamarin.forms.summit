﻿using System.Collections.Generic;

namespace Xamarin.Summit
{
    public class InformacoesResult
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public IEnumerable<string> Organizacao { get; set; }
        public IEnumerable<NotaResult> Notas { get; set; }
    }
}
