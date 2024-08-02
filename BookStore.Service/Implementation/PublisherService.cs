using BookStore.Domain.Models;
using BookStore.Repository.Interface;
using BookStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository<Publisher> _publisherRepository;

        public PublisherService(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void CreatePublisher(Publisher publisher)
        {
            this._publisherRepository.Insert(publisher);
        }

        public void DeletePublisher(Guid? id)
        {
            this._publisherRepository.Delete(this._publisherRepository.Get(id));
        }

        public List<Publisher> GetAllPublishers()
        {
            return this._publisherRepository.GetAll().ToList();
        }

        public Publisher GetDetailsForPublisher(Guid? id)
        {
            return this._publisherRepository.Get(id);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            this._publisherRepository.Update(publisher);
        }
    }
}
