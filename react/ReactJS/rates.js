/*
 получить курсы валют и отобразить в 
 виде списка




*/
const container = document.querySelector( "#rates" ); // DOM container

if(!container) {  // container 'id=rates' not found

    throw "container 'id=rates' not found";
}

const e = React.createElement;

class Rates extends React.Component {
    
    constructor( props ) {
        super( props );  //perent constructor
        this.ratesURL = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        this.state = {
            rates: [],
            shown: props.shown
        };

        this.saveRates = this.saveRates.bind( this );
    }

    render() {
        return e( 'div', {}, 
            this.state.rates.map(/*this.createElementFromNBUrate*/
                r => e( 'li', { key: r.r030 }, r.cc + " ( " + r.txt + " ) : " + r.rate )
                )  // второй вариант стрелочные функции
        );
    }

    createElementFromNBUrate( r ) {
        /*cc: "AUD", exchangedate: "28.12.2020", r030: 36, rate: 21.5453, txt: "Австралійський долар" */
        return React.createElement('li', {key: r.r030}, r.cc + " ( " + r.txt + " ) : " + r.rate );
    }

    saveRates( j ) {   //первый варинт вариант  функция нужно связвть
        
        let result = [];
        for (let i = 0; i < j.length; i++) {
            if( this.state.shown.includes( j[i].cc )){
                result.push( j[i] );
            }
        } 
        this.setState( st => {
            st.rates = result;
            console.log(j);
            return st;
        })
    }

    componentDidMount() {  // после встраивания компонента
        // апрос курса валют
        //  React не переопределяет AJAX функианал - берем сандартный
        fetch(this.ratesURL)    //запрос на URL методом GET
        .then(                  //Promise интерфейс по шаговое выолненение а не асинхроное  
            r => r.json()       // извлечь тело запроса JSON
            //r => r.text()     // извлечь тело запроса текстом
        )                           //
        .then(                  // результат тело ответа сервером(URL)  
            /* j => this.setState( {
                 rates : j
             } )      */ //второй вариант стрелочная функция не нужна привязка в constuctur     
             this.saveRates
             )
    }
}

ReactDOM.render( e( Rates, { shown: [ 'USD', 'GBP' ] }, null ), container); //shown ЧТО ОТОБРАЖАТЬ  