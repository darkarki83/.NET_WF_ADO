class Cont2 extends React.Component {
    constructor( props ) {
        super( props ) ;

        this.AddClick = this.AddClick.bind( this ); 
        this.state = {
            name: props.name,
            arr: []
        };
    }

    AddClick() {
        this.setState( st => {
            this.state.arr.push({name:  `obj${ this.state.arr.length + 1 }`, val: `${ 15 }`, id : `${ this.state.arr[this.state.arr.length - 1].id + 1 }`})
            this.setState({some:'val',arr:this.state.arr})
            }
        );
    }

    componentDidMount() {  // событие встраивания элемента ~ ready(JQuery) ~DOMContentLoaded
        this.setState(
            {
                arr : [
                    {name: "obj1", val: "10", id : 1},
                    {name: "obj2", val: "13", id : 3},
                    {name: "obj3", val: "15", id : 5},
                    {name: "obj4", val: "1", id : 12},
                    {name: "obj5", val: "125", id : 22}
                ]
        
            }
        )
    }

    render() {
        return e( 'div', {  },
            e( 'ul', { style: {border: '2px solid blue'} }, 
                this.state.arr.map(  // analog foreach
                obj => e( 'li', {key: obj.id}, obj.name) ) ),
            e( 'button', {style: {color:'red'},  onClick: this.AddClick }, 'Add')
        );
          
    }

}

ReactDOM.render( e(Cont2, { name: "artem" }, null), document.querySelector( "#container_2" ));