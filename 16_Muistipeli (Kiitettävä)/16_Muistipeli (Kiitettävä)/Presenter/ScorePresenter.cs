using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16_Muistipeli__Kiitettävä_.Model;
using _16_Muistipeli__Kiitettävä_.View;

namespace _16_Muistipeli__Kiitettävä_.Presenter
{
    public class ScorePresenter
    {
        private readonly IScoreView _view;
        private readonly IScoreModel _model;

        public ScorePresenter(IScoreView _view)
        {
            this._view = _view;
            this._model = new ScoreModel();
            _view.NaytaScores(_model.GetScores());
        }
    }
}
