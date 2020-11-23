using AutoMapper;
using Carlton.TestBed.Client.Shared.NavTree.Events;
using Carlton.TestBed.Client.Shared.NavTree.Models;
using Carlton.TestBed.Client.Shared.NavTree.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carlton.TestBed.Client
{
    public class TestBedMappingProfile : Profile
    {
        public TestBedMappingProfile()
        {
            CreateMap<SelectedNodeChangedEvent, SelectComponentRequest>();

        }
    }
}
