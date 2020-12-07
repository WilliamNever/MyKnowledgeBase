var UsInforListServerSide = React.createClass({
    getInitialState: function () {
        return {
            data: this.props.initialData,
            isLoaded: this.props.isLoaded,
            txtStatus: this.props.txtStatus,
            ResponseHeaders: this.props.ResponseHeaders
        };
    },
    componentDidMount: function () {
        this.LoadDataFromServer();
        //window.setInterval(this.LoadDataFromServer, this.props.pollInterval);
    },

    LoadDataFromServer: function () {
        $.ajax({
            type: 'post',
            url: this.props.url,
            headers: {
                mydefinedHeader: "Hello Header"
            },
            data: { ID: 0, UserName: 'MyUsName' },
            dataType: "json",
            success: function (data, textStatus, request) {
                if (this.isMounted()) {
                    //request.getResponseHeader('some_header');
                    this.setState({
                        data: data,
                        isLoaded: true,
                        txtStatus: textStatus,
                        ResponseHeaders: { ReturnHeader: request.getResponseHeader('ReturnHeader') }
                    });
                }
            }.bind(this)
        });
    },

    ToLoadData: function (event) {
        this.LoadDataFromServer();
    },

    ToClearData: function (event) {
        this.setState({
            data: [],
            isLoaded: false,
            txtStatus: "Clear!",
            ResponseHeaders: { ReturnHeader: "" }
        });
    },

    render: function () {
        var dlist = this.state.data;
        var itmList = '';
        if (dlist.length > 0) {
            //itmList = dlist.map(function (itm, index) {
            //    return (
            //        <tr key={itm.ID}>
            //            <td>{index}</td>
            //            <td>{itm.ID}</td>
            //            <td>{itm.UserName}</td>
            //            <td>{itm.FirstName}</td>
            //            <td>{itm.LastName}</td>
            //            <td>{itm.Age}</td>
            //        </tr>
            //    );
            //});
        }

        return (
        <table>
            <thead>
                <tr>
                    <td colSpan="3"><input type="button" onClick={this.ToLoadData} value="LoadData" /></td>
                    <td colSpan="3"><input type="button" onClick={this.ToClearData} value="ClearData" /></td>
                </tr>
                <tr>
                <td>No.</td>
                <td>ID</td>
                <td>UserName</td>
                <td>FirstName</td>
                <td>LastName</td>
                <td>Age</td>
                </tr>
            </thead>
            <tbody>
                {
                    dlist.map(function (itm, index) {
                        return (
                            <tr key={itm.ID}>
                            <td>{index + 1}</td>
                            <td>{itm.ID}</td>
                            <td>{itm.UserName}</td>
                            <td>{itm.FirstName}</td>
                            <td>{itm.LastName}</td>
                            <td>{itm.Age}</td>
                            </tr>
                    );
                    })
                }
            </tbody>
            <tfoot>
                <tr>
                    <td colSpan="2">Footer:</td>
            <td colSpan="2">{this.state.ResponseHeaders.ReturnHeader}</td>
            <td colSpan="2">{this.state.txtStatus}</td>
                </tr>
            </tfoot>
        </table>
        );
    },
});


var App2Server = React.createClass({
    render: function(){
        return(
        <h1 className="col-sm-4"> Hello World! </h1>
    );
    }
});