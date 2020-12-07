ReactDOM.render(<div className="row"><App /><span className="col-sm-3">aaa</span></div>, document.getElementById('contentXX'));

ReactDOM.render(<div className="row"><Exp01 i='1' /><span className="col-sm-3">Exp01</span></div>, document.getElementById('Exp01'));
ReactDOM.render(<div className="row"><Exp01 i='21' /><span className="col-sm-3">Exp01ex</span></div>, document.getElementById('Exp01ex'));

ReactDOM.render(<div className="row"><Exp01 i='1' /><App /></div>, document.getElementById('Exp01ex01'));

tmp = ReactDOM.render(
        <LikeButton />,
        document.getElementById('Exp02')
      );

ReactDOM.render(
      <WebSite />,
      document.getElementById('Exp03')
    );
/*
var idsToChange = ['Exp04', 'myTestID'];

$(document).ready(function () { //here can confirm the react runs after the document dom is built.
    idsToChange.forEach(function (v,x) {
        ReactDOM.render(
          <HelloMessage />,
          document.getElementById(idsToChange[x])
        );
    });
});
*/
$(".nlc").each(function () {
    ReactDOM.render(
          <HelloMessage />,
          $(this)[0]
        );
});