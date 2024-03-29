﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using engenharia_de_software_pb.BLL.Models;
using engenharia_de_software_pb.Data.DAOs;
using engenharia_de_software_pb.Data.Interfaces;

namespace engenharia_de_software_pb.Data.Repositories
{
    public class NotasRepository : IRepository<Notas>
    {
        public readonly IDao<Notas> _notasDao;

        public NotasRepository(IDao<Notas> notasDao)
        {
            _notasDao = notasDao;
        }

        public async Task<Notas> Create(Notas entity)
        {
            try
            {
                await _notasDao.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return entity;
            }

        }

        public async Task<bool> Delete(Notas entity)
        {
            try
            {
                await _notasDao.Delete(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public async Task<IEnumerable<Notas>> GetAll()
        {
            try
            {
                return await _notasDao.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Notas>();
            }
        }

        public async Task<Notas?> GetById(int id)
        {
            try
            {
                return await _notasDao.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<Notas?> GetByIdAsNoTracking(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Notas>> GetByRelatedId(string type, int id)
        {
            try
            {
                return await _notasDao.GetByRelatedId(type, id);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Notas>();
            }
        }

        public Task<IEnumerable<Notas?>> GetMultipleByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Notas> Update(Notas entity)
        {
            try
            {
                return await _notasDao.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return entity;
            }
        }
    }
}
