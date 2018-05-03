﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public interface IAgendaService
    {
        Task<IEnumerable<AgendaWrapper>> GetAgendaAsync();
    }

    public class AgendaService : ServiceBase, IAgendaService
    {
        public async Task<IEnumerable<AgendaWrapper>> GetAgendaAsync()
            => await Task.Run(() =>
               {

                   using (var realm = GetRealmInstance())
                   {
                       var result = new List<AgendaWrapper>();
                       var agendas = realm.All<Agenda>().ToList();
                       foreach (var item in agendas)
                       {
                           var agendaWrapper = item.ConvertTo<AgendaWrapper>();
                           agendaWrapper.TimeLine = item.TimeLine.Select(s =>
                           {
                               var timeLine = new TimeLineWrapper { Hora = s.Hora, Id = s.Id, Titulo = s.Titulo };
                               timeLine.Descricao = s.Palestrantes.Any() ? string.Join(", ", s.Palestrantes.AsEnumerable().Select(p => p.Nome)) : s.Descricao;
                               return timeLine;
                           }).ToList();
                           result.Add(agendaWrapper);
                       }
                       return result;
                   }
               });
    }
}

