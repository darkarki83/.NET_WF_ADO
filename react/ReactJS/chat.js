const cont = document.body.querySelector( "#container" ); 
if( !cont ) {
    throw "Container not located";
}

const e = React.createElement;

class Cont extends React.Component {
    constructor( props ) {
        super( props ) ;

        this.onNikChange = this.onNikChange.bind( this ); 
        this.onMsgChange = this.onMsgChange.bind( this ); 
        this.sendClick = this.sendClick.bind( this );
        this.updateChat = this.updateChat.bind( this );

        this.state = {
            arrm: [],
            nik: ''
        };
       
        // почемуто срабатует один раз 
        /*setTimeout(() => {
            this.updateChat()
        }, 1000);*/

        // 3.1
        setInterval(() => this.updateChat(), 1000);
    }

    onNikChange(evn) {
        this.setState( {nik: evn.target.value} ); 
    }

    onMsgChange(evn) {
        this.setState( {msg: evn.target.value} ); 
    }

    sendClick() {
        if( this.state.nik == '' ){
            alert( 'Enter nik ');
            return;
        }
        else if( this.state.msg.length < 3 ){
            alert( 'Enter message ');
            return;
        }                                                                                          
        fetch( 'https://chat.momentfor.fun?author=' + this.state.nik + '&msg=' + this.state.msg )
        .then( r => r.json() )
        .then( j => {
            if( j.status != 1 ) {
                alert( 'Server error' );
                return ;
            } 
            this.setState( { arrm: j.data }); 
            //console.log(j.data);
        })

        // 2
        document.getElementsByClassName("mytext")[0].value = '';
    }

    // 3.2
    updateChat(  ) {
        fetch( 'https://chat.momentfor.fun' )
        .then( r => r.json() )
        .then( j => {
            if( j.status != 1 ) {
                alert( 'Server error' );
                return ;
            } 
            this.setState( { arrm: j.data });
        })
    }
    
    componentDidMount() {  // событие встраивания элемента ~ ready(JQuery) ~DOMContentLoaded
        fetch( 'https://chat.momentfor.fun' )
        .then( r => r.json() )
        .then( j => {
            if( j.status != 1 ) {
                alert( 'Server error' );
                return ;
            } 
            this.setState( { arrm: j.data });
        })
/*
        var notes = document.getElementsByClassName("mytext");
        console.log(notes[0].value);*/
    }
/*
    JSX :
    <>
        <span>NikNik : </span>
        <input onChange={this.onNikChange} />
        <div>
            <p>Nik1: Mess>
            <p>Nik2: Mess>
            <p>Nik3: Mess>
            <p>Nik4: Mess>
        </div>
        <b>{this.state.nik}</b>
        <textarea onChange={this.onMsgChange}>Hello</textarea>
        <button onClick={this.sendClick}> Send </button>
    </>
*/
    render() {
        return(
            e( React.Fragment, { } , 
                e( 'span', { }, 'NikNik :' ),
                e('input', {  onChange: this.onNikChange }, null),
                e( 'div', {}, 
                    this.state.arrm.map( m =>                                     // 1
                        e('p', {key: m.id }, m.author + ':' + m.text + ' ::: ' + m.moment ))
                ),
                e( 'div', {className:'sender'}, 
                e( 'b', {},  this.state.nik + ' :' ), 
                e( 'textarea', {className:'mytext', id:'mytext', onChange: this.onMsgChange }, null ),
                e( 'button', { onClick: this.sendClick}, 'Send')
                ),
            )
        );
    }

}

ReactDOM.render( e(Cont, { }, null), cont);