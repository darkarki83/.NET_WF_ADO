const e = React.createElement;

class Cont1 extends React.Component {
    constructor( props ) {
        super( props ) ;
        this.state = {
            name: props.name,
            arr: [
                {name: "obj1", val: "10", id : 1},
                {name: "obj2", val: "13", id : 3},
                {name: "obj3", val: "15", id : 5}
            ]       }
    }

    render() {
        return e( 'div', { style: {border: '2px solid tomato'} },  // div - container
            e( 'h1', {style: {color:'gray'}, id: 'hello'} , 'Hello ' + this.state.name), // h1 1st child
            e( 'ul' , {} ,          // ul 2st child
            /*[
                e('li' , {key: this.state.arr[0].id} , this.state.arr[0].name ),  // li 1st child of ul 
                e('li' , {key: this.state.arr[1].id} , this.state.arr[1].name ),
                e('li' , {key: this.state.arr[2].id} , this.state.arr[2].name )

            ] */
            this.state.arr.map(  // analog foreach
                    obj => e( 'li', {key: obj.id}, obj.name)
                )  
            )

        )}

}

ReactDOM.render( e(Cont1, { name: "artem" }, null), document.querySelector( "#container" ));