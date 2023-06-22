using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroClienteReservaDll.DOs;
using CadastroClienteReservaApi.Models;
using CadastroClienteReservaApi.DAOs;

namespace CadastroClienteReservaApi.Models.Extensoes
{
    public static class ExtensoesModelDO
    {
        public static ClienteDO ToDO(this Cliente obj)
        {
            return new ClienteDO
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Documento = obj.Documento,
                Telefone = obj.Telefone
            };
        }

        public static IList<ClienteDO> ToDO(this IList<Cliente> listaModels)
        {
            var lista = new List<ClienteDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }

        public static async Task<Cliente> ToModel(this ClienteDO objDO)
        {
            Cliente? obj = null;

            if (objDO.Id != null)
            {
                var dao = new ClienteDAO();
                obj = await dao.RetornarPorIdAsync(objDO.Id);
            }

            if (obj == null)
                obj = new Cliente();

            obj.Nome = objDO.Nome;
            obj.Documento = objDO.Documento;
            obj.Telefone = objDO.Telefone;

            return obj;
        }

        public static async Task<IList<Cliente>> ToModel(this IList<ClienteDO> listaDO)
        {
            var lista = new List<Cliente>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }

        public static ClienteReservaDO ToDO(this ClienteReserva obj)
        {
            return new ClienteReservaDO
            {
                Id = obj.Id,
                IdCliente = obj.IdCliente,
                DataReserva = obj.DataReserva,
                QuantidadePessoas = obj.QuantidadePessoas
            };
        }

        public static IList<ClienteReservaDO> ToDO(this IList<ClienteReserva> listaModels)
        {
            var lista = new List<ClienteReservaDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }

        public static async Task<ClienteReserva> ToModel(this ClienteReservaDO objDO)
        {
            ClienteReserva? obj = null;

            if (objDO.Id != null)
            {
                var dao = new ClienteReservaDAO();
                obj = await dao.RetornarPorIdAsync(objDO.Id);
            }

            if (obj == null)
                obj = new ClienteReserva();

            obj.IdCliente = objDO.IdCliente;
            obj.DataReserva = objDO.DataReserva;
            obj.QuantidadePessoas = objDO.QuantidadePessoas;

            return obj;
        }

        public static async Task<IList<ClienteReserva>> ToModel(this IList<ClienteReservaDO> listaDO)
        {
            var lista = new List<ClienteReserva>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }
    }
}