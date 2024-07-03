import defaultHomeStyle from '../../styles/defaulthome-style.module.css';
import {SIGN_IN} from '../../routes/routespath.jsx';


const DefaultHome = () =>{
    return(
        <div className={defaultHomeStyle.mainDefaultHome}>
            <div className={defaultHomeStyle.cardDefaultHome}>
                <h1>Watch</h1>
                <p>Your optimal solution for managing students and professors in
                    your training program</p>
                <p><a href={SIGN_IN}>Sign In</a> now to take full advantage of all our tools and resources</p>
            </div>
        </div>
    )
}

export default DefaultHome;