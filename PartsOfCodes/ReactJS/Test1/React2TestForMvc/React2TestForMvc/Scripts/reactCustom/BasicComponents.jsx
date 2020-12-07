var tmp = {};

var App = React.createClass({
    render: function(){
        return(
        <h1 className="col-sm-4"> Hello World! </h1>
    );
    }
});

var Exp01 = React.createClass({
    render: function(){
        return(
        <h1 className="col-sm-4">It is {this.props.i == 1 ? 'True!' : 'False'}</h1>
    );
    }
});

var LikeButton = React.createClass({
    getInitialState: function() {
        return {
            liked: false,
            inputString: "",
        };
    },
    handleClick: function(event) {
        if (this.isMounted())
        {
            this.setState({ liked: !this.state.liked, inputString: this.refs.myTextInput.value});
        }
    },
    ChangeTxt: function(event)
    {
        this.setState({ inputString: event.target.value });

        //tmp = event.target.value;
    },
    render: function() {
        var text = this.state.liked ? this.state.inputString : 'No.....';
        var value = this.state.inputString;
        return (
            <div>
                <input type="text" ref="myTextInput" value={value} onChange={this.ChangeTxt} />
              <p>
                <b>{text}</b>
              </p>
              <input type='button' value='ClickToSwitch' onClick={this.handleClick}/>
          </div>
    );
    },
    setValueIn: function (str)
    {
        this.setState({ inputString: str });
        this.refs.myTextInput.value = str;
    }
});

var WebSite = React.createClass({
    getInitialState: function() {
        return {
            name: "菜鸟教程",
            site: "http://www.runoob.com"
        };
    },
     
    render: function() {
        return (
          <div>
            <Name name={this.state.name} />
            <Link site={this.state.site} />
          </div>
        );
}
});

var Name = React.createClass({
    render: function() {
        return (
          <h1>{this.props.name}</h1>
        );
    }
});

var Link = React.createClass({
    render: function() {
        return (
          <a href="javascript:void(0);">
          {this.props.site}
        </a>
    );
}
});

var Content = React.createClass({
    render: function() {
        return  <div>
                <input type="text" value={this.props.myDataProp} onChange={this.props.updateStateProp} /> 
                <h4>{this.props.myDataProp}</h4>
                </div>;
    }
});
var HelloMessage = React.createClass({
    getInitialState: function() {
        return {value: 'Hello Runoob!'};
    },
    handleChange: function(event) {
        this.setState({value: event.target.value});
    },
    render: function() {
        var value = this.state.value;
        return <div>
                <Content myDataProp = {value} 
        updateStateProp = {this.handleChange}></Content>
     </div>;
    }
});
