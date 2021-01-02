/*
home work

1) отображение в виле таблицы
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
        };

        this.saveRates = this.saveRates.bind( this );
    }

    render() {
        return e( 'table', {}, 
            e('th', {}, 
            e('td', { }, 'Adbr name'), e('td', {}, 'Name'), e('td', {}, 'Rate'),
            this.state.rates.map(this.createElementFromNBUrate)  // функции отображения(отрисовки)
        ));
    }

    createElementFromNBUrate( r ) {
        /*cc: "AUD", exchangedate: "28.12.2020", r030: 36, rate: 21.5453, txt: "Австралійський долар" */

        return e('tr', {key: r.r030}, 
            e('td', { style: {border: '2px solid blue'}} , r.cc ) , e('td', { style: {border: '2px solid blue'}} , r.txt ), e('td', { style: {border: '2px solid blue'}} , r.rate)); 

    }

    saveRates( j ) {  

        this.setState( st => {
            st.rates = j;
            // console.log(j);
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

ReactDOM.render( e( Rates, { }, null ), container); //shown ЧТО ОТОБРАЖАТЬ  