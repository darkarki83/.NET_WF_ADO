
const cont = document.getElementById( "container" )
        if( !cont ) {
            throw "Container not located";
        }

        class Cont extends React.Component {
            render() {
                return <h2> JSX works </h2>;
            }
        } 
        ReactDOM.render( <Cont />, cont);