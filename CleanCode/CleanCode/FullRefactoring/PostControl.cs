using System;
using System.Web.UI.WebControls;

namespace CleanCode.FullRefactoring
{
    public class PostControl : System.Web.UI.UserControl
    {
        private readonly PostRepository repository;
        private readonly PostValidator validator;
        private Label PostBody { get; set; }
        private Label PostTitle { get; set; }
        private int? PostId { get; set; }

        public PostControl()
        {
            repository = new PostRepository();
            validator = new PostValidator();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                TrySavePost();
            else
                DisplayPost();
        }

        private void TrySavePost()
        {
            var post = GetPost();
            var results = validator.Validate(post);

            if (results.IsValid)
                repository.SavePost(post);
            else
                DisplayErrors(results);
        }

        private void DisplayErrors(ValidationResult results)
        {
            var errorSummary = GetErrorSummaryControl();

            foreach (var error in results.Errors)
            {
                var errorMessage = GetErrorLabel(error);
                if (errorMessage == null)
                    errorSummary.Items.Add(new ListItem(error.ErrorMessage));
                else
                    errorMessage.Text = error.ErrorMessage;
            }
        }

        private BulletedList GetErrorSummaryControl()
            => (BulletedList)FindControl("ErrorSummary");

        private Label GetErrorLabel(ValidationError error)
            => FindControl(error.PropertyName + "Error") as Label;

        private void DisplayPost()
        {
            var postId = Convert.ToInt32(Request.QueryString["id"]);
            var entity = repository.GetPost(postId);
            PostBody.Text = entity.Body;
            PostTitle.Text = entity.Title;
        }

        private Post GetPost()
            => new Post()
            {
                Id = Convert.ToInt32(PostId.Value),
                Title = PostTitle.Text.Trim(),
                Body = PostBody.Text.Trim()
            };

    }
}