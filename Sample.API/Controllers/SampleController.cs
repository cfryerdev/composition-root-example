﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain.Managers;

namespace Sample.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SampleController : ControllerBase
	{
		private SampleManager sampleManager;

		public SampleController(SampleManager manager)
		{
			sampleManager = manager;
		}

		[HttpGet]
		public string Get()
		{
			return sampleManager.Get();
		}
	}
}
