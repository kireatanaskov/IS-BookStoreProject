﻿using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interface
{
    public interface IPublisherService
    {
        List<Publisher> GetAllPublishers();
        Publisher GetPublisher(Guid? id);
        void CreatePublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Guid? id);
    }
}
