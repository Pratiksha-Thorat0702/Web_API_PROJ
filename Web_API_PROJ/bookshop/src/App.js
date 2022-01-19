import logo from './logo.svg';
import './App.css';
import img1 from './images/user.png';
import img2 from './images/un.png';
import img3 from './images/password.png';
function App(){
  return(
    <div className="main">

    <div className="sub-main">
 
    <div>
      <div className="imgs">
        <div className="container-image">
          <img src={img1} alt="img1" className="img1"/>
      
       </div>
        </div>
        <h1>Login Page</h1>
        <div>
          <img  src={img2} alt="img2" className="img2"/>
          <input type="text" placeholder="UserName"className="Name"/>
        </div>
        <div>
          <img  src={img3} alt="img3" className="img3"/>
          <input type="text" placeholder="Password"className="Name"/>
        </div>
        <button>
          Login
        </button>
        <div>

        </div>

    </div>
    </div>
   </div>
  );
}

/*function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
} */

export default App;
