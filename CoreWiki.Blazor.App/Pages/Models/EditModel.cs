using CoreWiki.ViewModels;
using CoreWiki.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using CoreWiki.Application.Articles.Managing.Commands;
using CoreWiki.Application.Articles.Managing.Exceptions;
using CoreWiki.Application.Articles.Managing.Queries;
using CoreWiki.Application.Common;
using Microsoft.AspNetCore.Authorization;
using CoreWiki.Areas.Identity;
using Microsoft.AspNetCore.Blazor.Services;

namespace CoreWiki.Blazor.App.Pages.Models
{

	[Authorize(Policy = PolicyConstants.CanEditArticles)]
	public class EditModel : PageModel
	{

		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly IUriHelper _uriHelper;

		public EditModel(IMediator mediator, IMapper mapper, IUriHelper uriHelper)
		{
			_mediator = mediator;
			_mapper = mapper;
			_uriHelper = uriHelper;
		}

		//[BindProperty]
		public ArticleEdit Article { get; set; }

		public async Task<IActionResult> OnGetAsync(string slug)
		{
			if (slug == null)
			{
				return null;
			}

			var article = await _mediator.Send(new GetArticleQuery(slug));

			if (article == null)
			{
				return new ArticleNotFoundResult();
			}

			Article = _mapper.Map<ArticleEdit>(article);

			return Page();

		}

		public RedirectResult Save()
		{
			if (!ModelState.IsValid)
			{
				return null;
			}

			var cmd = _mapper.Map<EditArticleCommand>(Article);
			cmd =_mapper.Map(User, cmd);

			var result = _mediator.Send(cmd).GetAwaiter().GetResult();

			if (result.Exception is InvalidTopicException)
			{
				ModelState.AddModelError("Article.Topic", result.Exception.Message);
				return null;
			} else if (result.Exception is ArticleNotFoundException)
			{
				return new RedirectResult("/") { _uriHelper = _uriHelper };
			}

			var query = new GetArticlesToCreateFromArticleQuery(UrlHelpers.URLFriendly(Article.Topic));
			var listOfSlugs = _mediator.Send(query).GetAwaiter().GetResult();

			if (listOfSlugs.Any())
			{
				return new RedirectResult($"/CreateArticleFromLink/{UrlHelpers.URLFriendly(Article.Topic)}") { _uriHelper = _uriHelper };
			}

			return new RedirectResult($"/Details/{UrlHelpers.URLFriendly(Article.Topic)}") { _uriHelper = _uriHelper };
		}

		
	}

}
