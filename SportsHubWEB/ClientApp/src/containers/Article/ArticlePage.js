import 'bootstrap/dist/css/bootstrap.css';
import React, { Component } from 'react';
import {Container} from "reactstrap";

const server = {
    imageURL: "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
    title: "First ever Title",
    articleText: "European countries must not turn on each other amid growing tensions over Covid vaccine supplies, the president of the EU Parliament has said.\n" +
        "\n" +
        "The call for unity comes as EU leaders hold virtual talks to discuss supplies and improving distribution across the bloc's 27 member states.\n" +
        "\n" +
        "Some countries have complained that doses have not been distributed fairly.\n" +
        "\n" +
        "The meeting on Thursday will also see EU leaders decide whether to approve proposals to toughen export controls.\n" +
        "\n" +
        "Such controls could affect supply to the UK, where Prime Minister Boris Johnson has warned against imposing \"blockades\".\n" +
        "\n" +
        "European Commission head Ursula von der Leyen tweeted that the summit would \"ensure that Europeans get their fair share of vaccines\". She also said the EU had exported some 77 million doses to 33 countries since December, making the bloc the world's largest vaccine exporter.\n" +
        "\n" +
        "Some EU states, led by Austria, are calling for a revision in the bloc's distribution method after failing to obtain enough doses earlier this year.\n" +
        "\n" +
        "Why is the EU having vaccine problems?\n" +
        "Where is the Oxford-AstraZeneca vaccine made?\n" +
        "EU tussle with UK over AstraZeneca jabs escalates\n" +
        "\"There is no sense in us turning on each other, just as there is no sense in thinking that others are doing much better,\" European Parliament President David-Maria Sassoli said at a press conference on Thursday.\n" +
        "\n" +
        "\"The more unity we show, the more trust we will inspire,\" he added. \"Salvation lies in working together.\"\n" +
        "\n" +
        "Vaccine rollouts in EU states have started sluggishly, and the bloc has blamed pharmaceutical companies - primarily AstraZeneca - for not delivering its promised doses. The company denies that it is failing to honour its contract."
};


export class Article extends Component{
    render () {
        return (
            <>
                <Container className="text-center">
                    
                    <div className="title-a">
                        <h1 >{server.title}</h1>
                    </div>
                    
                    <div className="img-a">
                        <img src= {server.imageURL} alt={server.title}/>
                    </div>
                    <hr/>
                    
                    <div className="text-a">
                        <h3 className="text-lg-left">{server.articleText}</h3>
                    </div>
                    
                    <hr/>
                </Container>
               
            </>
        )
}}
