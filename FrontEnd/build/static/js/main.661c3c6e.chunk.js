(this["webpackJsonppoker-online"]=this["webpackJsonppoker-online"]||[]).push([[0],{38:function(e,t,a){},54:function(e,t,a){},56:function(e,t,a){"use strict";a.r(t);var n=a(0),s=a.n(n),o=a(27),c=a.n(o),i=(a(38),a(10)),r=a.n(i),d=a(32),u=a(15),l=a(8),f=a(25),p=a(58),m=a(59),b=a(2),_=function(e){var t=e.joinGame,a=Object(n.useState)(),s=Object(l.a)(a,2),o=s[0],c=s[1],i=Object(n.useState)(),r=Object(l.a)(i,2),d=r[0],u=r[1];return Object(b.jsx)(p.a,{className:"login",onSubmit:function(e){e.preventDefault(),t(o,d)},children:Object(b.jsxs)(p.a.Group,{children:[Object(b.jsx)(p.a.Control,{placeholder:"name",onChange:function(e){return c(e.target.value)}}),Object(b.jsx)(p.a.Control,{placeholder:"password",type:"password",onChange:function(e){return u(e.target.value)}}),Object(b.jsx)(m.a,{variant:"success",type:"submit",disabled:!o||!d,children:"Join"})]})})},j=function(e){var t=e.users;return Object(b.jsxs)("div",{className:"user-list",children:[Object(b.jsx)("h4",{children:"Connected Users"}),t.map((function(e,t){return Object(b.jsx)("h5",{children:e.username},t)}))]})},g=a(17),h=function(e){var t=e.createRoom,a=(e.user,e.enterMoney),s=Object(n.useState)(),o=Object(l.a)(s,2),c=o[0],i=o[1];return Object(b.jsx)(p.a,{className:"login",onSubmit:function(e){e.preventDefault(),t(c,a)},children:Object(b.jsxs)(p.a.Group,{children:[Object(b.jsx)(p.a.Control,{placeholder:"Room Name",onChange:function(e){return i(e.target.value)}}),Object(b.jsx)(m.a,{variant:"success",type:"submit",disabled:!c,children:"Join Room"})]})})},v=function(e){var t=e.createRoom,a=e.user,s=e.enterMoney,o={state:!0,color:"green",text:"New Room"},c={state:!1,color:"red",text:"Hide"},i=Object(n.useState)(o),r=Object(l.a)(i,2),d=r[0],u=r[1];return Object(b.jsxs)("div",{children:[Object(b.jsxs)(m.a,{variant:"primary",onClick:function(){u(d.state?c:o)},style:{backgroundColor:d.color,width:"100%"},className:"btn",children:[" ",d.text]},"new"),d.state||Object(b.jsx)(h,{createRoom:t,user:a,enterMoney:s})]})},x=a(19),O=function(e){var t=e.rooms,a=e.joinRoom,s=e.createRoom,o=e.user,c=Object(n.useState)({x:parseInt(o.money/2)}),i=Object(l.a)(c,2),r=i[0],d=i[1];return Object(b.jsxs)("div",{id:"room-list",className:"room-list",children:[Object(b.jsx)("h4",{id:"availableRooms",children:"Available Rooms"}),Object(b.jsxs)("div",{children:[Object(b.jsxs)("label",{children:[" ",r.x," $ "]}),Object(b.jsx)(x.a,{xmin:parseInt(o.money/10),xmax:o.money,x:r.x,onChange:function(e){var t=e.x;return d((function(e){return Object(g.a)(Object(g.a)({},e),{},{x:t})}))}})]}),Object(b.jsx)(v,{createRoom:s,user:o,enterMoney:r.x}),t.map((function(e){return Object(b.jsxs)(m.a,{onClick:function(){a(e.id,r.x)},children:[e.name," ",e.numberOfPlayers,"/5"]},e.id)}))]})},k=a(57),y=a(29),R=function(e){var t=e.sendMessage,a=Object(n.useState)(""),s=Object(l.a)(a,2),o=s[0],c=s[1];return Object(b.jsx)(p.a,{onSubmit:function(e){e.preventDefault(),t(o),c("")},children:Object(b.jsxs)(k.a,{children:[Object(b.jsx)(y.a,{type:"user",placeholder:"message...",onChange:function(e){return c(e.target.value)},value:o}),Object(b.jsx)(k.a.Append,{children:Object(b.jsx)(m.a,{variant:"primary",type:"submit",disabled:!o,children:"Send"})})]})})},S=function(e){var t=e.messages,a=Object(n.useRef)();return Object(n.useEffect)((function(){if(a&&a.current){var e=a.current,t=e.scrollHeight,n=e.clientHeight;a.current.scrollTo({left:0,top:t-n,behavior:"smooth"})}}),[t]),Object(b.jsx)("div",{ref:a,className:"message-container",children:t.map((function(e,t){return Object(b.jsxs)("div",{className:"user-message",children:[Object(b.jsx)("div",{className:"message bg-primary",children:e.message}),Object(b.jsx)("div",{className:"from-user",children:e.username})]},t)}))})},w=function(e){var t=e.sendMessage,a=e.messages,n=e.users;e.closeConnection,e.joinRoom;return Object(b.jsxs)("div",{children:[Object(b.jsx)(j,{users:n}),Object(b.jsxs)("div",{className:"chat",children:[Object(b.jsx)(S,{messages:a}),Object(b.jsx)(R,{sendMessage:t})]})]})},C=function(e){var t=e.joinRoom,a=e.rooms,n=e.createRoom,s=e.user;return Object(b.jsx)("div",{className:"available-rooms",children:Object(b.jsx)(O,{rooms:a,joinRoom:t,createRoom:n,user:s})})},I=a.p+"static/media/poker_table.87ff0626.png",T=a.p+"static/media/user.73a0bc1f.png",N=a.p+"static/media/background.0eba5a55.png",M=a.p+"static/media/back_of_card.f07ef3ff.png",A=a.p+"static/media/dealer.d4c14bda.png",L=a.p+"static/media/2_of_hearts.c2cb81fb.png",q=a.p+"static/media/3_of_hearts.d50c0a08.png",P=a.p+"static/media/4_of_hearts.436fe356.png",F=a.p+"static/media/5_of_hearts.f407aa6f.png",E=a.p+"static/media/6_of_hearts.3fff0835.png",J=a.p+"static/media/7_of_hearts.fdc0fa83.png",W=a.p+"static/media/8_of_hearts.cff7b360.png",$=a.p+"static/media/9_of_hearts.a896f989.png",D=a.p+"static/media/10_of_hearts.bf72f319.png",G=a.p+"static/media/jack_of_hearts.f623f209.png",H=a.p+"static/media/queen_of_hearts.746a7ee8.png",B=a.p+"static/media/king_of_hearts.67c7a876.png",U=a.p+"static/media/ace_of_hearts.5a72df7d.png",z=a.p+"static/media/2_of_spades.b9261a5e.png",V=a.p+"static/media/3_of_spades.5aea0220.png",K=a.p+"static/media/4_of_spades.8f066844.png",Q=a.p+"static/media/5_of_spades.bffe8ee0.png",X=a.p+"static/media/6_of_spades.1cbd30ed.png",Y=a.p+"static/media/7_of_spades.1517728e.png",Z=a.p+"static/media/8_of_spades.c8c922f0.png",ee=a.p+"static/media/9_of_spades.dcce4a16.png",te=a.p+"static/media/10_of_spades.c9f933df.png",ae=a.p+"static/media/jack_of_spades.3fa41aad.png",ne=a.p+"static/media/queen_of_spades.c9de6912.png",se=a.p+"static/media/king_of_spades.fda148e5.png",oe=a.p+"static/media/ace_of_spades.a24049b6.png",ce=a.p+"static/media/2_of_clubs.d5d968ca.png",ie=a.p+"static/media/3_of_clubs.bbea0442.png",re=a.p+"static/media/4_of_clubs.e6ba95ce.png",de=a.p+"static/media/5_of_clubs.4397c46f.png",ue=a.p+"static/media/6_of_clubs.b44599ca.png",le=a.p+"static/media/7_of_clubs.efd12036.png",fe=a.p+"static/media/8_of_clubs.78dfd743.png",pe=a.p+"static/media/9_of_clubs.8e317f62.png",me=a.p+"static/media/10_of_clubs.1e849b92.png",be=a.p+"static/media/jack_of_clubs.316b8303.png",_e=a.p+"static/media/queen_of_clubs.ef480115.png",je=a.p+"static/media/king_of_clubs.b70624b5.png",ge=a.p+"static/media/ace_of_clubs.f2dd09c0.png",he=a.p+"static/media/2_of_diamonds.a51b192d.png",ve=a.p+"static/media/3_of_diamonds.b78fe80c.png",xe=a.p+"static/media/4_of_diamonds.e86dcc4c.png",Oe=a.p+"static/media/5_of_diamonds.ced27ce3.png",ke=a.p+"static/media/6_of_diamonds.b19504c1.png",ye=a.p+"static/media/7_of_diamonds.fe13bd1b.png",Re=a.p+"static/media/8_of_diamonds.b1389da2.png",Se=a.p+"static/media/9_of_diamonds.ae87f8c3.png",we=a.p+"static/media/10_of_diamonds.f5f2d107.png",Ce=a.p+"static/media/jack_of_diamonds.afe516e9.png",Ie=a.p+"static/media/queen_of_diamonds.91139054.png",Te=a.p+"static/media/king_of_diamonds.87c79c7e.png",Ne=a.p+"static/media/ace_of_diamonds.326a309b.png",Me={poker_table:I,user:T,background:N,back_of_card:M,dealer:A,two_of_hearts:L,three_of_hearts:q,four_of_hearts:P,five_of_hearts:F,six_of_hearts:E,seven_of_hearts:J,eight_of_hearts:W,nine_of_hearts:$,ten_of_hearts:D,jack_of_hearts:G,queen_of_hearts:H,king_of_hearts:B,ace_of_hearts:U,two_of_spades:z,three_of_spades:V,four_of_spades:K,five_of_spades:Q,six_of_spades:X,seven_of_spades:Y,eight_of_spades:Z,nine_of_spades:ee,ten_of_spades:te,jack_of_spades:ae,queen_of_spades:ne,king_of_spades:se,ace_of_spades:oe,two_of_clubs:ce,three_of_clubs:ie,four_of_clubs:re,five_of_clubs:de,six_of_clubs:ue,seven_of_clubs:le,eight_of_clubs:fe,nine_of_clubs:pe,ten_of_clubs:me,jack_of_clubs:be,queen_of_clubs:_e,king_of_clubs:je,ace_of_clubs:ge,two_of_diamonds:he,three_of_diamonds:ve,four_of_diamonds:xe,five_of_diamonds:Oe,six_of_diamonds:ke,seven_of_diamonds:ye,eight_of_diamonds:Re,nine_of_diamonds:Se,ten_of_diamonds:we,jack_of_diamonds:Ce,queen_of_diamonds:Ie,king_of_diamonds:Te,ace_of_diamonds:Ne},Ae=["two","three","four","five","six","seven","eight","nine","ten","jack","queen","king","ace"],Le=["clubs","hearts","spades","diamonds"],qe=(a(52),a(31)),Pe=(a(53),function(e){var t=e.joinRoom,a=e.LeaveRoom,s=e.sendMessage,o=e.connection,c=e.messages,i=e.roomStatus,r=e.user,d=946,u=Math.round(490.974),f=100,p=[[473,400],[184,337],[217,84]];p[3]=[d-p[2][0],p[2][1]],p[4]=[d-p[1][0],p[1][1]];for(var _=500/6,j=121,h=[120,95],v=[],O=-2;O<3;O++)v.push([473+O*(_+6),17*u/40]);var k=Object.keys(Me).length,y=Object(n.useState)(0),R=Object(l.a)(y,2),S=R[0],C=R[1],I=Object(n.useState)(),T=Object(l.a)(I,2),N=T[0],M=T[1],A=Object(n.useState)(!1),L=Object(l.a)(A,2),q=L[0],P=L[1],F=Object(n.useState)(!1),E=Object(l.a)(F,2),J=(E[0],E[1]),W=Object(n.useState)(i.turnTime),$=Object(l.a)(W,2),D=$[0],G=$[1],H=Object(n.useState)({y:0}),B=Object(l.a)(H,2),U=B[0],z=B[1];Object(n.useEffect)((function(){var e=setInterval((function(){D>0&&0!=i.stage&&5!=i.stage&&G(D-1),0===D&&clearInterval(e)}),1e3);return function(){clearInterval(e)}}));var V=function(e,t,a){e.drawImage(N.user,p[t][0]-50,p[t][1]-50,f,f);var n=1;if(t<3&&(n=-1),i.stage>0&&1==a.isActive){if(2==a.cards.length)for(var s=0;s<2;s++)e.drawImage(N[Ae[a.cards[s].value]+"_of_"+Le[a.cards[s].suit]],p[t][0]-_/2+n*h[s],p[t][1]-60.5,_,j);else for(s=0;s<2;s++)e.drawImage(N.back_of_card,p[t][0]-_/2+n*h[s],p[t][1]-60.5,_,j);a.position==i.dealerPosition&&e.drawImage(N.dealer,p[t][0],p[t][1],40,40)}a.isWinner&&5==i.stage&&(e.font="50px Arial",e.strokeStyle="black",e.fillStyle="white",e.lineWidth=6,e.strokeText("Winner!",p[t][0],p[t][1]-77),e.fillText("Winner!",p[t][0],p[t][1]-77)),e.font="20px Arial",e.strokeStyle="black",e.fillStyle="white",e.lineWidth=7,e.textAlign="center",e.backgroundColor="white",e.strokeText(a.username+a.moneyInTable+"$ "+a.moneyInTurn,p[t][0],p[t][1]+77),e.fillText(a.username+a.moneyInTable+"$ "+a.moneyInTurn,p[t][0],p[t][1]+77)};return Object(n.useEffect)((function(){M((function(){var e=new Object;for(var t in Me)e[t]=new Image,e[t].src=Me[t],e[t].onload=function(){C((function(e){return e+1}))};return e}))}),[]),Object(n.useEffect)((function(){if(!(S<k)){var e=document.getElementById("myCanvas").getContext("2d");e.drawImage(N.poker_table,0,0,d,u);for(var t=0;t<i.users.length;t++)V(e,(i.users[t].position-r.position+5)%5,i.users[t]);r.position==i.talkingPosition?P(!0):P(!1),r.position==i.dealerPosition?J(!0):J(!1),function(e){if(void 0!=i.cardsOnTable)for(var t=0;t<i.cardsOnTable.length;t++)e.drawImage(N[Ae[i.cardsOnTable[t].value]+"_of_"+Le[i.cardsOnTable[t].suit]],v[t][0]-_/2,v[t][1]-60.5,_,j);e.font="20px Arial",e.fillStyle="white",e.textAlign="center",e.backgroundColor="white",e.fillText(i.pot+"$",473,5*u/8)}(e),console.log(i.turnTime),G(i.turnTime)}}),[S,i]),Object(b.jsxs)("div",{children:[Object(b.jsxs)("div",{style:{width:"".concat(d,"px"),height:"".concat(u,"px"),position:"relative"},children:[Object(b.jsx)("canvas",{style:{position:"absolute"},id:"myCanvas",width:d,height:u}),Object(b.jsx)("div",{style:{position:"absolute",width:120,height:120,marginLeft:"".concat(p[(i.talkingPosition-r.position+5)%5][0]-60,"px"),marginTop:"".concat(p[(i.talkingPosition-r.position+5)%5][1]-60,"px")},children:0!=i.stage&&5!=i.stage&&Object(b.jsx)(qe.a,{value:D,maxValue:i.turnTime})}),Object(b.jsxs)("div",{style:{position:"absolute"},children:[Object(b.jsx)(m.a,{style:{position:"absolute"},variant:"danger",onClick:function(){return a()},children:"Leave Room"}),0!=i.stage&&5!=i.stage&&Object(b.jsxs)("div",{children:[Object(b.jsx)("div",{style:{position:"absolute",marginLeft:"543px",marginTop:"343px",height:"90px"},children:q&&i.turnStake<r.moneyInTable&&Object(b.jsx)(x.a,{style:{color:"#7d0015",height:"120px"},yreverse:!0,axis:"y",ymin:i.turnStake,ymax:r.moneyInTable,y:U.y,onChange:function(e){var t=e.y;return z((function(e){return Object(g.a)(Object(g.a)({},e),{},{y:t})}))}})}),Object(b.jsxs)("div",{className:"button-list",style:{marginLeft:"".concat(567.6,"px"),marginTop:"".concat(2*u/3,"px")},children:[Object(b.jsx)(m.a,{disabled:!q||r.moneyInTurn<i.turnStake,variant:"dark",onClick:function(){o.invoke("ReceiveCheck")},children:"Check"},"Check"),Object(b.jsxs)(m.a,{disabled:!q||r.moneyInTurn==i.turnStake,variant:"dark",onClick:function(){o.invoke("ReceiveCall")},children:["Call ",i.turnStake>r.moneyInTurn?i.turnStake-r.moneyInTurn:null]},"Call"),Object(b.jsxs)(m.a,{disabled:!q||i.turnStake>=r.moneyInTable,variant:"dark",onClick:function(){o.invoke("ReceiveRaise",U.y)},children:["Raise ",U.y]},"Raise"),Object(b.jsx)(m.a,{disabled:!q,variant:"dark",onClick:function(){o.invoke("ReceiveFold")},children:"Fold"},"Fold")]})]})]})]}),Object(b.jsx)(w,{sendMessage:s,messages:c,users:i.users,joinRoom:t})]})}),Fe=function(e){var t=e.joinRoom,a=e.LeaveRoom,n=e.rooms,s=e.sendMessage,o=e.messages,c=e.roomStatus,i=e.createRoom,r=e.user,d=e.connection;return Object(b.jsx)("div",{children:null==r.roomId?Object(b.jsx)(C,{joinRoom:t,createRoom:i,rooms:n,user:r}):Object(b.jsx)(Pe,{joinRoom:t,connection:d,LeaveRoom:a,sendMessage:s,messages:o,roomStatus:c,user:r})})},Ee=function(e){var t=e.user;return Object(b.jsxs)("div",{children:[Object(b.jsxs)("h4",{style:{textAlign:"left",position:"absolute",padding:"10px"},children:["Hello ",t.username,"!"]}),Object(b.jsxs)("h4",{style:{textAlign:"right",padding:"10px"},children:[t.money,"$"]})]})},Je=(a(54),a(55),a(3),function(){var e=Object(n.useState)(),t=Object(l.a)(e,2),a=t[0],s=t[1],o=Object(n.useState)([]),c=Object(l.a)(o,2),i=c[0],p=c[1],m=Object(n.useState)([]),j=Object(l.a)(m,2),g=j[0],h=j[1],v=Object(n.useState)([]),x=Object(l.a)(v,2),O=x[0],k=x[1],y=Object(n.useState)({}),R=Object(l.a)(y,2),S=R[0],w=R[1],C=function(){var e=Object(u.a)(r.a.mark((function e(t,a){var n;return r.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.prev=0,(n=(new f.a).withUrl("https://localhost:44382/poker").configureLogging(f.b.Information).build()).serverTimeoutInMilliseconds=1e5,n.on("RoomStatus",(function(e){console.log(e),h(e)})),n.on("ReceiveMessage",(function(e,t){console.log(e),p((function(a){return[].concat(Object(d.a)(a),[{username:e,message:t}])}))})),n.on("AllRoomsStatus",(function(e){console.log(e),k(e.rooms)})),n.on("Alert",(function(e){alert(e)})),n.on("UserStatus",(function(e){console.log(e),w(e)})),n.onclose((function(e){s(),p([]),h([]),w({}),k([])})),e.next=11,n.start();case 11:return e.next=13,n.invoke("SignIn",t,a);case 13:s(n),e.next=19;break;case 16:e.prev=16,e.t0=e.catch(0),console.log(e.t0);case 19:case"end":return e.stop()}}),e,null,[[0,16]])})));return function(t,a){return e.apply(this,arguments)}}(),I=function(){var e=Object(u.a)(r.a.mark((function e(t,n){return r.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.prev=0,p([]),e.next=4,a.invoke("JoinRoom",t,n);case 4:e.next=9;break;case 6:e.prev=6,e.t0=e.catch(0),console.log(e.t0);case 9:case"end":return e.stop()}}),e,null,[[0,6]])})));return function(t,a){return e.apply(this,arguments)}}(),T=function(){var e=Object(u.a)(r.a.mark((function e(t,n){return r.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.prev=0,e.next=3,a.invoke("createRoom",t,parseInt(n));case 3:e.next=8;break;case 5:e.prev=5,e.t0=e.catch(0),console.log(e.t0);case 8:case"end":return e.stop()}}),e,null,[[0,5]])})));return function(t,a){return e.apply(this,arguments)}}(),M=function(){var e=Object(u.a)(r.a.mark((function e(t){return r.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.prev=0,e.next=3,a.invoke("SendMessage",t);case 3:e.next=8;break;case 5:e.prev=5,e.t0=e.catch(0),console.log(e.t0);case 8:case"end":return e.stop()}}),e,null,[[0,5]])})));return function(t){return e.apply(this,arguments)}}(),A=function(){var e=Object(u.a)(r.a.mark((function e(){return r.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,a.invoke("LeaveRoom");case 2:case 3:case"end":return e.stop()}}),e)})));return function(){return e.apply(this,arguments)}}();return Object(b.jsx)("div",{style:{zIndex:"-2",backgroundImage:"url(".concat(N,")"),height:"120%",width:"100%",position:"absolute"},children:Object(b.jsxs)("div",{className:"bounding-box",children:[Object(b.jsx)("div",{className:"background-gray"}),a&&Object(b.jsx)(Ee,{user:S}),Object(b.jsxs)("div",{className:"app",children:[Object(b.jsx)("h2",{children:"Poker Online"}),Object(b.jsx)("hr",{className:"line"}),a?Object(b.jsx)(Fe,{joinRoom:I,rooms:O,sendMessage:M,messages:i,roomStatus:g,user:S,createRoom:T,LeaveRoom:A,connection:a}):Object(b.jsx)(_,{joinGame:C})]})]})})}),We=function(e){e&&e instanceof Function&&a.e(3).then(a.bind(null,60)).then((function(t){var a=t.getCLS,n=t.getFID,s=t.getFCP,o=t.getLCP,c=t.getTTFB;a(e),n(e),s(e),o(e),c(e)}))};c.a.render(Object(b.jsx)(s.a.StrictMode,{children:Object(b.jsx)(Je,{})}),document.getElementById("root")),We()}},[[56,1,2]]]);
//# sourceMappingURL=main.661c3c6e.chunk.js.map