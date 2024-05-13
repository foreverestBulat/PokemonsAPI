<template>
    <div class="search">
        <div class="horizontal">
            <div class="vertical">
                <div class="block-text">
                    <div class="text">Who are you looking for?</div>
                </div>                
                <div class="form">
                    <input 
                        :value="search"
                        @input="searchName">
                    <div class="vertical-btn">
                        <button class="button"> GO </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data () {
            return {
                search: null
            }
        },
        methods: {
            async searchName(event){
                this.search = event.target.value;
                this.$emit('search-name', {
                    name: this.search,
                    method: 'searchName'
                })
            }
        }
    }
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Quicksand:wght@600&display=swap');

.search {
    /* width: 100%; */
    height: 500px;
    background-image: url("https://digwallpapers.com/wallpapers/full/7/a/4/70773-3840x2160-pokemon-pokeball-background-desktop-4k.jpg");
    background-position: center;
    background-size: 100%;
    display: flex;
    justify-content: right;
    font-size: 40px;
    font-family: "Quicksand", sans-serif;
    font-optical-sizing: auto;
    font-weight: 600;
    font-style: normal;
    color: white;
}

.block-text {
    display: flex;
    justify-content: center;
    margin-bottom: 30px;
}

.text {
    width: 300px;
}

.horizontal {
    width: 50%;
    display: flex;
    justify-content: center;
    align-items: center;
}

.form {
    background-color: white;
    border: none;
    border-radius: 30px;
    height: 50px;
    width: 500px;
    display: flex;
    justify-content: center;
    overflow: hidden;
}

input {
    width: 100%;
    border: none;
    font-size: 17px;
    font-family: "Quicksand", sans-serif;
    margin-left: 10px;
}

input:focus {
    outline: none;
}

.vertical {
    display: flex;
    flex-direction: column;
    justify-content: center;
}

.vertical-btn {
    width: 40%;
    display: flex;
    justify-content: center;
    align-items: center;
}

.button {
    background-color: aqua;
    height: 90%;
    width: 97%;
    align-items: center;
    border-radius: 30px;
    display: flex;
    justify-content: center;
}
</style>