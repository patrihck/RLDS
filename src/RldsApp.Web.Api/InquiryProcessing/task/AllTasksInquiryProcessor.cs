using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RldsApp.Data.DataProcessing.task;
using PagedTaskDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.Task>;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class AllTasksInquiryProcessor : IAllTasksInquiryProcessor
    {
        public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

        private readonly IMapper _autoMapper;
        private readonly ICommonLinkService _commonLinkService;
        private readonly IAllTasksDataProcessor _queryProcessor;
        private readonly ITaskLinkService _taskLinkService;

		public AllTasksInquiryProcessor(IAllTasksDataProcessor queryProcessor, IMapper autoMapper, 
			ITaskLinkService taskLinkService, ICommonLinkService commonLinkService)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
            _taskLinkService = taskLinkService;
            _commonLinkService = commonLinkService;
		}

        public PagedTaskDataInquiryResponse GetTasks(PagedDataRequest requestInfo)
        {
            var queryResult = _queryProcessor.GetTasks(requestInfo);
            var tasks = GetTasks(queryResult.QueriedItems).ToList();

            var inquiryResponse = new PagedTaskDataInquiryResponse
            {
                Items = tasks,
                PageCount = queryResult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };

			AddLinksToInquiryResponse(inquiryResponse);

			return inquiryResponse;
        }

        public virtual void AddLinksToInquiryResponse(PagedTaskDataInquiryResponse inquiryResponse)
        {
            inquiryResponse.AddLink(_taskLinkService.GetAllTasksLink());

            _commonLinkService.AddPageLinks(inquiryResponse,
                GetCurrentPageQueryString(inquiryResponse),
                GetPreviousPageQueryString(inquiryResponse),
                GetNextPageQueryString(inquiryResponse)
            );
        }

        public virtual IEnumerable<Task> GetTasks(IEnumerable<Data.Entities.Task> taskEntities)
        {
            var tasks = taskEntities.Select(x => _autoMapper.Map<Task>(x)).ToList();

            tasks.ForEach(x =>
            {
                _taskLinkService.AddSelfLink(x);
                _taskLinkService.AddLinksToChildObjects(x);
            });

            return tasks;
        }

        public virtual string GetCurrentPageQueryString(PagedTaskDataInquiryResponse inquiryResponse)
        {
            return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
        }

        public virtual string GetPreviousPageQueryString(PagedTaskDataInquiryResponse inquiryResponse)
        {
            return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
        }

        public virtual string GetNextPageQueryString(PagedTaskDataInquiryResponse inquiryResponse)
        {
            return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
        }
    }
}